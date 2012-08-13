using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;
using Procent.Samples.TcpIp.Client.WinForms.Utils;

namespace Procent.Samples.TcpIp.Client.WinForms
{
	public partial class FrmMain : Form, INotifyPropertyChanged
	{
		#region Fields & Properties

		private static readonly Color _connectedColor = Color.Green;
		private static readonly Color _disconnectedColor = Color.Red;

		private Color _currentStateColor;

		public Color CurrentStateColor
		{
			get { return _currentStateColor; }
			private set
			{
				_currentStateColor = value;
				OnPropertyChanged("CurrentStateColor");
			}
		}

		#endregion

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		#region Initialization

		public FrmMain()
		{
			InitializeComponent();
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			lblState.DataBindings.Add("BackColor", this, "CurrentStateColor");
			CurrentStateColor = _disconnectedColor;

			Program.Client.ConnectionEstablished += Client_ConnectionEstablished;
			Program.Client.ConnectionLost += Client_ConnectionLost;
			MessageNotifications.TextMessageReceived += MessageNotifications_TextMessageReceived;
		}

		#endregion

		#region Controls events handlers

		private void btnSend_Click(object sender, EventArgs e)
		{
			SendMessage();
			tbMessage.Clear();
		}

		private void tbReceiver_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsNumber(e.KeyChar));
		}

		#endregion

		#region Client interaction

		private void SendMessage()
		{
			TextMessage message = new TextMessage(tbMessage.Text, int.Parse(tbReceiver.Text), Program.Id, DateTime.Now);
			Program.Client.SendMessage(new Package(new PackageHeader(), message));
		}

		private void MessageNotifications_TextMessageReceived(object sender, TextMessageEventArgs e)
		{
			this.InvokeIfRequired(delegate
				{
					tbConversation.AppendText(e.Message.ToDisplayString());
				});
		}

		private void Client_ConnectionEstablished(object sender, EventArgs e)
		{
			CurrentStateColor = _connectedColor;
		}

		void Client_ConnectionLost(object sender, EventArgs e)
		{
			CurrentStateColor = _disconnectedColor;
		}

		#endregion
	}
}