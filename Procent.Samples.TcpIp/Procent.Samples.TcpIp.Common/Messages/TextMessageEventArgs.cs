using System;

namespace Procent.Samples.TcpIp.Common.Messages
{
	public class TextMessageEventArgs : EventArgs
	{
		public TextMessage Message { get; private set; }

		public TextMessageEventArgs(TextMessage message)
		{
			Message = message;
		}
	}
}