using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Procent.Samples.TcpIp.Client.MessageHandlers;
using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;
using Procent.Samples.TcpIp.Common.Utils;

namespace Procent.Samples.TcpIp.Client
{
	public class Client : IDisposable
	{
		#region Events

		/// <summary>
		/// Raised when a connection with server is established.
		/// </summary>
		public event EventHandler ConnectionEstablished;
		protected void OnConnectionEstablished()
		{
			Debug.WriteLine("Connection with server established");

			_isRunning = true;

			if (ConnectionEstablished != null)
				ConnectionEstablished(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raised when a connection with server is lost.
		/// </summary>
		public event EventHandler ConnectionLost;
		protected void OnConnectionLost()
		{
			Debug.WriteLine("Connection with server lost");

			_isRunning = false;

			if (ConnectionLost != null)
				ConnectionLost(this, EventArgs.Empty);

			if (_autoReconnect)
				Reconnect();
		}

		#endregion

		#region Fields & Properties

		private TcpClient _client;
		private NetworkStream _stream
		{
			get { return _client.GetStream(); }
		}

		private bool _isRunning;

		private bool _autoReconnect;
		/// <summary>
		/// Configures the client with AutoReconnect behavior. Default is false.
		/// </summary>
		public bool AutoReconnect
		{
			get { return _autoReconnect; }
			set { _autoReconnect = value; }
		}

		private int _reconnectInterval = 2000;
		/// <summary>
		/// If AutoReconnect is ON - determines the interval between connection attempts in milliseconds.
		/// Default is 2000.
		/// </summary>
		public int ReconnectInterval
		{
			get { return _reconnectInterval; }
			set { _reconnectInterval = value; }
		}

		#endregion

		#region Ctors

		/// <summary>
		/// Static ctor registering message handlers.
		/// </summary>
		static Client()
		{
			MessageHandlerManager.RegisterHandler<TextMessage>(new TextMessageHandler());
		}

		/// <summary>
		/// Creates a default instance of Client - no autoreconnect set.
		/// </summary>
		public Client()
		{

		}

		/// <summary>
		/// Creates a new instance of Client.
		/// </summary>
		/// <param name="autoReconnect">True if the client should automatically reconnect on lost or failed connection; otherwise - false. Default is false.</param>
		public Client(bool autoReconnect)
			: this()
		{
			_autoReconnect = autoReconnect;
		}

		/// <summary>
		/// Creates a reconnecting instance of Client.
		/// </summary>
		/// <param name="reconnectInterval">Interval between reconnect attempts, in milliseconds. Default is 2000.</param>
		public Client(int reconnectInterval)
			: this(true)
		{
			_reconnectInterval = reconnectInterval;
		}

		#endregion

		/// <summary>
		/// Performs a given operation catching all exceptions and raising ConnectionLost event if one occurs.
		/// </summary>
		/// <param name="operation">Operation to perform.</param>
		void RaiseConnectionLostOnException(Action operation)
		{
			try
			{
				operation();
			}
			catch
			{
				OnConnectionLost();
			}
		}

		#region Connecting / Disconnecting / Reconnecting

		/// <summary>
		/// Connects to the server and starts a new thread listening for a communication from server to client.
		/// </summary>
		public void Connect()
		{
			if (_isDisposed)
				throw new ObjectDisposedException("Client");

			if (_isRunning)
				return;

			try
			{
				_client = new TcpClient();
				_client.Connect(Settings.HOST_NAME, Settings.PORT);

				OnConnectionEstablished();

				// Procedure listening for server messages.
				ThreadStart threadStart = delegate
					{
						BinaryFormatter formatter = new BinaryFormatter();
						RaiseConnectionLostOnException(delegate
							{
								while (_isRunning)
								{
									Package package = (Package)formatter.Deserialize(_stream);
									MessageHandlerManager.HandleMessage(this, package.Message);
								}
							});
					};

				new Thread(threadStart) {IsBackground = true}.Start();
			}
			catch
			{
				if (_autoReconnect)
					Reconnect();
				else
					throw;
			}
		}

		public void Disconnect()
		{
			if (!_isRunning)
				return;
			_isRunning = false;

			Dispose();
		}

		private void Reconnect()
		{
			Debug.WriteLine("Reconnecting...");

			DisposeClient();

			ThreadPool.QueueUserWorkItem(delegate
			{
				Thread.Sleep(_reconnectInterval);
				Connect();
			});
		}

		#endregion

		public void SendMessage(Package package)
		{
			RaiseConnectionLostOnException(delegate
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(_stream, package);
			});
		}

		#region Disposing

		bool _isDisposed;

		~Client()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (_isDisposed)
				return;
			_isDisposed = true;

			Disconnect();
			DisposeClient();

			GC.SuppressFinalize(this);
		}

		private void DisposeClient()
		{
			if (_client != null)
			{
				this.IgnoreErrorsDuring(_client.Close);
				if (_client.Client != null)
					this.IgnoreErrorsDuring(_client.Client.Close);
			}
		}

		#endregion
	}
}