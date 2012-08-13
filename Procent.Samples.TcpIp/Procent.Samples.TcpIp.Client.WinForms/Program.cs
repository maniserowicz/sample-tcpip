using System;
using System.Windows.Forms;
using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Extensions.Messages;

namespace Procent.Samples.TcpIp.Client.WinForms
{
	static class Program
	{
		public static Client Client;
		public static int Id;
		public static string Password;

		[STAThread]
		static void Main()
		{
			FrmLogin frmLogin = new FrmLogin();
			frmLogin.ShowDialog();
			Id = frmLogin.Id;
			Password = frmLogin.Password;

			Client = new Client(true);
			Client.ConnectionEstablished += delegate
				{
					Client.SendMessage(
										new Package(new PackageHeader(),
										new LoginWithPasswordMessage(Id, Password))
									   );
				};

			FrmMain form = new FrmMain();
			form.Load += delegate
				{
					Client.Connect();
				};

			Application.ApplicationExit += delegate
				{
					Client.Dispose();
				};

			Application.Run(form);
		}
	}
}
