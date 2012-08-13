using System;

namespace Procent.Samples.TcpIp.Common.Messages
{
	public class LoginMessageEventArgs : EventArgs
	{
		public LoginMessage Message { get; private set; }

		public LoginMessageEventArgs(LoginMessage message)
		{
			Message = message;
		}
	}
}