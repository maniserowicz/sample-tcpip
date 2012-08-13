using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;
using Procent.Samples.TcpIp.Common.Utils;
using Procent.Samples.TcpIp.Server.MessageHandlers;

namespace Procent.Samples.TcpIp.Server
{
	/// <summary>
	/// Listens for new connections and creats a channel for communication with any single client.
	/// </summary>
	public class Server : IDisposable
	{
		readonly TcpListener _listener = new TcpListener(IPAddress.Any, Settings.PORT);

		#region Channels collection

		readonly List<SingleClientChannel> _channels = new List<SingleClientChannel>();
		readonly object _syncRootChannels = new object();

		/// <summary>
		/// Performs an operation on channels collection with synchronization in mind.
		/// All operations that may change the state of the collection should be passed to this method.
		/// </summary>
		/// <param name="operation">Operation to perform.</param>
		void UseChannelsCollection(Action operation)
		{
			int channelsCountBefore;
			int channelsCountAfter;
			lock (_syncRootChannels)
			{
				channelsCountBefore = _channels.Count;
				operation();
				channelsCountAfter = _channels.Count;
			}

			if (channelsCountBefore != channelsCountAfter)
				Debug.WriteLine(string.Format("Number of clients changed; currently serving {0} clients.", _channels.Count));
		}

		#endregion

		#region Ctors

		/// <summary>
		/// A static ctor initializing registering handlers for messages.
		/// </summary>
		static Server()
		{
			MessageHandlerManager.RegisterHandler<LoginMessage>(new LoginMessageHandler());
			MessageHandlerManager.RegisterHandler<TextMessage>(new TextMessageHandler());
		}

		/// <summary>
		/// Default ctor, configures handlers that need configuration.
		/// </summary>
		public Server()
		{
			((TextMessageHandler)MessageHandlerManager.GetHandler<TextMessage>()).Server = this;
		}

		#endregion

		#region Start / Stop / IsRunning

		public bool IsRunning { get; private set; }

		public void Start()
		{
			if (_isDisposed)
				throw new ObjectDisposedException("Server");

			if (IsRunning)
				return;
			IsRunning = true;

			ThreadPool.QueueUserWorkItem(delegate
				{
					PerformAcceptingClients();
				});
		}

		public void Stop()
		{
			if (!IsRunning)
				return;
			IsRunning = false;

			Dispose();
		}

		#endregion

		#region Serving clients

		private void PerformAcceptingClients()
		{
			_listener.Start();

			while (IsRunning)
			{
				try
				{
					// wait for a new client
					TcpClient newClient = _listener.AcceptTcpClient();

					// create a channel for communication with the new client
					SingleClientChannel channel = new SingleClientChannel(this, newClient);
					channel.ClientDisconnected += channel_ClientDisconnected;

					// add to the clients collection
					UseChannelsCollection(() => _channels.Add(channel));

					// start communication
					channel.StartListening();
				}
				catch (Exception exc)
				{
					Debug.WriteLine("PerformAcceptingClients: " + exc);
				}
			}
		}

		void channel_ClientDisconnected(object sender, EventArgs e)
		{
			SingleClientChannel channel = (SingleClientChannel)sender;

			// remove disconnected client from collection of active clients
			UseChannelsCollection(() => _channels.Remove(channel));

			// dispose of the client ignoring all exceptions
			this.IgnoreErrorsDuring(channel.Dispose);
		}

		#endregion

		#region Sending messages

		/// <summary>
		/// Send a TextMessage to all clients.
		/// </summary>
		internal void SendTextMessage(TextMessage message)
		{
			SendTcpMessageTo(
				_channels,
				new Package(new PackageHeader(), message)
				);
		}

		/// <summary>
		/// Sends a TextMessage to client with a given Id.
		/// </summary>
		internal void SendTextMessage(TextMessage message, int clientId)
		{
			SendTcpMessageTo(
				_channels.FindAll(channel => channel.Id == clientId),
				new Package(new PackageHeader(), message)
				);
		}

		/// <summary>
		/// Asynchronously send a package to a list of given clients.
		/// </summary>
		/// <param name="channels"></param>
		/// <param name="package"></param>
		static void SendTcpMessageTo(List<SingleClientChannel> channels, Package package)
		{
			channels.ForEach(channel =>
				{
					ThreadPool.QueueUserWorkItem(delegate
						{
							channel.SendPackage(package);
						});
				});
		}

		#endregion

		#region IDisposable

		bool _isDisposed;

		~Server()
		{
			Dispose();
		}

		/// <summary>
		/// Implements a simplified version of IDisposable pattern.
		/// </summary>
		public void Dispose()
		{
			if (_isDisposed)
				return;
			_isDisposed = true;

			Stop();
			_listener.Stop();
			UseChannelsCollection(delegate
				{
					foreach (var channel in _channels)
					{
						channel.Dispose();
					}
				});

			GC.SuppressFinalize(this);
		}

		#endregion
	}
}