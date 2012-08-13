using System;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Client
{
	/// <summary>
	/// A central source of events which can be raised by MessageHandlers that need to alert the system about a specific type of message.
	/// </summary>
	public static class MessageNotifications
	{
		public static event EventHandler<TextMessageEventArgs> TextMessageReceived;
		internal static void RaiseTextMessageReceived(TextMessageEventArgs e)
		{
			if (TextMessageReceived != null)
				TextMessageReceived(null, e);
		}
	}
}