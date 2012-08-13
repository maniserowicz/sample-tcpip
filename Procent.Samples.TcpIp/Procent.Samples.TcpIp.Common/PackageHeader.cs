using System;

namespace Procent.Samples.TcpIp.Common
{
	/// <summary>
	/// Contains additional information about sent messages.
	/// </summary>
	[Serializable]
	public class PackageHeader
	{
		public DateTime Created { get; private set; }

		public PackageHeader()
		{
			Created = DateTime.Now;
		}
	}
}