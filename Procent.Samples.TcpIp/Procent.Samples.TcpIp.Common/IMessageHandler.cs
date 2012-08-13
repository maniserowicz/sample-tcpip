using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Common
{
	public interface IMessageHandler
	{
		void HandleMessage(object receiver, MessageBase message);
	}
}