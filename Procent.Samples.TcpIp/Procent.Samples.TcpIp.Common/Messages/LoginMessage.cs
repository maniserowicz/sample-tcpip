using System;

namespace Procent.Samples.TcpIp.Common.Messages
{
    [Serializable]
	public class LoginMessage : MessageBase
	{
    	public int Id { get; private set; }

    	public LoginMessage(int id)
    	{
    		Id = id;
    	}

		public override string ToString()
		{
			return string.Format("LoginMessage, Id: {0}.", Id);
		}
	}
}