using System;
using System.Windows.Forms;

namespace Procent.Samples.TcpIp.Client.WinForms.Utils
{
	public static class ControlExtensions
	{
		public static void InvokeIfRequired(this Control instance, Action operation)
		{
			if (instance.InvokeRequired)
			{
				instance.Invoke(operation);
			}
			else
			{
				operation();
			}
		}
	}
}