using System;
using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Server.Console.MessageHandlers
{
	public class IgnoringAnonymousHandler : IMessageHandler
	{
		private IMessageHandler _nextHandler;

		public IgnoringAnonymousHandler(IMessageHandler nextHandler)
		{
			if (nextHandler == null)
				throw new ArgumentNullException("nextHandler");

			_nextHandler = nextHandler;
		}

		public void HandleMessage(object receiver, MessageBase message)
		{
			SingleClientChannel channel = (SingleClientChannel)receiver;
			if (channel.Id > 0)
				_nextHandler.HandleMessage(receiver, message);
			else
				System.Console.WriteLine("Message sent from anonymous client - ignoring.");
		}
	}
}