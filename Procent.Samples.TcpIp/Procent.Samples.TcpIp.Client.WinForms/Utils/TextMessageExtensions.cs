using System;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Client.WinForms.Utils
{
	public static class TextMessageExtensions
	{
		public static string ToDisplayString(this TextMessage instance)
		{
			return string.Format("{0} ({1}):{2}{3}{2}", instance.Sender, instance.Sent, Environment.NewLine, instance.Content);
		}
	}
}
