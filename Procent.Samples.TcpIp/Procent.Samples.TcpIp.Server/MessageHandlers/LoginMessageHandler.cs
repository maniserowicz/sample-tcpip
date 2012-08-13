using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Server.MessageHandlers
{
	/// <summary>
	/// Handles LoginMessage - sets Id of the receiving channel.
	/// </summary>
	public class LoginMessageHandler : IMessageHandler
	{
		public void HandleMessage(object receiver, MessageBase message)
		{
			LoginMessage loginMessage = (LoginMessage)message;

			SingleClientChannel channel = (SingleClientChannel)receiver;
			channel.Id = loginMessage.Id;
		}
	}
}