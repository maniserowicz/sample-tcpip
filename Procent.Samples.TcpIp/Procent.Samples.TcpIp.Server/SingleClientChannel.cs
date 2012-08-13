using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Utils;

namespace Procent.Samples.TcpIp.Server
{
	/// <summary>
	/// Responsible for communication with a single client.
	/// </summary>
	public class SingleClientChannel : IDisposable
	{
		#region  Events

		/// <summary>
		/// Raised when a client ends communication or an exception occurs.
		/// </summary>
		public event EventHandler ClientDisconnected;
		public void OnClientDisconnected()
		{
			if (ClientDisconnected != null)
				ClientDisconnected(this, EventArgs.Empty);
		}

		#endregion

		#region Fields and properties

		private readonly Server _server;
		private readonly TcpClient _client;
		private NetworkStream _stream
		{
			get { return _client.GetStream(); }
		}

		public int Id { get; set; }

		#endregion

		/// <summary>
		/// Performs a given operation catching all exceptions and raising ClientDisconnected event if one occurs.
		/// </summary>
		/// <param name="operation">Operation to perform.</param>
		void RaiseClientDisconnectedOnError(Action operation)
		{
			try
			{
				operation();
			}
			catch
			{
				OnClientDisconnected();
			}
		}

		#region Ctors

		public SingleClientChannel(Server server, TcpClient client)
		{
			if (client == null)
				throw new ArgumentNullException("client");
			if (server == null)
				throw new ArgumentNullException("server");

			_client = client;
			_server = server;
		}

		#endregion

		#region Listening

		/// <summary>
		/// Starts a new thread listening for a communication from client to server.
		/// </summary>
		public void StartListening()
		{
			new Thread(PerformListening) { IsBackground = true }.Start();
		}

		/// <summary>
		/// Receives all data sent by a client and passes to handlers.
		/// </summary>
		private void PerformListening()
		{
			Debug.WriteLine("Connection with client " + _client.Client.RemoteEndPoint + " started.");

			BinaryFormatter formatter = new BinaryFormatter();
			RaiseClientDisconnectedOnError(() =>
				{
					while (_server.IsRunning)
					{
						Package package = (Package)formatter.Deserialize(_stream);
						Debug.WriteLine(string.Format("[{0}] Package received (sent at {1}):{2}{3}", DateTime.Now, package.Header.Created, Environment.NewLine, package.Message));
						MessageHandlerManager.HandleMessage(this, package.Message);
					}
				});
		}

		#endregion

		#region IDisposable

		private bool _isDisposed;

		~SingleClientChannel()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (_isDisposed)
				return;
			_isDisposed = true;

			this.IgnoreErrorsDuring(_client.Close);
			if(_client.Client != null)
				this.IgnoreErrorsDuring(_client.Client.Close);

			GC.SuppressFinalize(this);
		}

		#endregion

		public void SendPackage(Package package)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			RaiseClientDisconnectedOnError(() =>
				{
					formatter.Serialize(_stream, package);
				});
		}
	}
}