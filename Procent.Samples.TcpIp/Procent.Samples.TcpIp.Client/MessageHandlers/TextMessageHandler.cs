using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Client.MessageHandlers
{
	/// <summary>
	/// Handles TextMessage - informs the rest of a system that it is received by MessageNotifications mechanism.
	/// </summary>
	public class TextMessageHandler : IMessageHandler
	{
		public void HandleMessage(object receiver, MessageBase message)
		{
			TextMessage textMessage = (TextMessage)message;

			MessageNotifications.RaiseTextMessageReceived(new TextMessageEventArgs(textMessage));
		}
	}
}