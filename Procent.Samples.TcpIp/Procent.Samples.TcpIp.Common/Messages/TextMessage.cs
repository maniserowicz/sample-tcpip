using System;

namespace Procent.Samples.TcpIp.Common.Messages
{
	[Serializable]
	public class TextMessage : MessageBase
	{
		public DateTime Sent { get; set; }
		public string Content { get; private set; }
		public int Sender { get; set; }
		public int Receiver { get; private set; }

		public TextMessage(string content, int receiver, int sender, DateTime sent)
		{
			Content = content;
			Receiver = receiver;
			Sender = sender;
			Sent = sent;
		}

		public override string ToString()
		{
			return string.Format("TextMessage from {0} to: {1}", Sender, Receiver);
		}
	}
}