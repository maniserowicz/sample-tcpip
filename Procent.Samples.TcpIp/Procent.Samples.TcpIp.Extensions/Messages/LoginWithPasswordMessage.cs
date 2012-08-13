using System;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Extensions.Messages
{
	[Serializable]
	public class LoginWithPasswordMessage : LoginMessage
	{
		public string Password { get; private set; }

    	public LoginWithPasswordMessage(int id, string password):base(id)
    	{
    		Password = password;
    	}

		public override string ToString()
		{
			return string.Format("LoginWithPasswordMessage, Id: {0}, Password: {1}.", Id, Password);
		}
	}
}