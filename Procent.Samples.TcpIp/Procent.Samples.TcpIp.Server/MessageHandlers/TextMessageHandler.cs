using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Server.MessageHandlers
{
	/// <summary>
	/// Handles TextMessage - passes it to the Server for further processing, i.e. sending if to the receiver.
	/// </summary>
	public class TextMessageHandler : IMessageHandler
	{
		public Server Server;

		public void HandleMessage(object receiver, MessageBase message)
		{
			TextMessage textMessage = (TextMessage)message;

			Server.SendTextMessage(textMessage, textMessage.Receiver);
		}
	}
}