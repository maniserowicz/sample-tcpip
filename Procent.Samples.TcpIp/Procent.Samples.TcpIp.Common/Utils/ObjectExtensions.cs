using System;
using System.Diagnostics;

namespace Procent.Samples.TcpIp.Common.Utils
{
	public static class ObjectExtensions
	{
		/// <summary>
		/// Performs a given operation catching all possible exceptions and ignoring them.
		/// </summary>
		public static void IgnoreErrorsDuring(this object instance, Action operation)
		{
			try
			{
				operation();
			}catch (Exception exc)
			{
				Debug.WriteLine(new StackFrame(1).GetMethod().Name + exc);
			}
		}
	}
}