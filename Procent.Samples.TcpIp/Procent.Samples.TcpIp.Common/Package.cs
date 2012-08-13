using System;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Common
{
	/// <summary>
	/// A wrapper around messages sent betweend server and clients.
	/// </summary>
	[Serializable]
	public class Package
	{
		public PackageHeader Header { get; private set; }
		public MessageBase Message { get; private set; }

		public Package(PackageHeader header, MessageBase message)
		{
			Header = header;
			Message = message;
		}
	}
}