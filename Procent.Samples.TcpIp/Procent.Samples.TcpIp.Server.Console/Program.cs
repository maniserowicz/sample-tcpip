using System.Diagnostics;
using Procent.Samples.TcpIp.Common;
using Procent.Samples.TcpIp.Common.Messages;
using Procent.Samples.TcpIp.Extensions.Messages;
using Procent.Samples.TcpIp.Server.Console.MessageHandlers;
using Procent.Samples.TcpIp.Server.MessageHandlers;

namespace Procent.Samples.TcpIp.Server.Console
{
	class Program
	{
		static void Main()
		{
			Debug.Listeners.Add(new TextWriterTraceListener(System.Console.Out));

			System.Console.WriteLine(string.Format("Starting server on port {0}...", Settings.PORT));

			using (Server server = new Server())
			{
				// DEMO: adds a handler for a custom message type
				MessageHandlerManager.RegisterHandler<LoginWithPasswordMessage>(new LoginMessageHandler());

				// DEMO: replaces a default handler with a custom one
				IMessageHandler oldHandler = MessageHandlerManager.GetHandler<TextMessage>();
				MessageHandlerManager.ForceRegisterHandler<TextMessage>(new IgnoringAnonymousHandler(oldHandler));

				server.Start();

				System.Console.WriteLine("Server started.");
				System.Console.WriteLine("Press ENTER to stop the server.");
				System.Console.ReadLine();
			}

			System.Console.WriteLine("Server stopped.");
		}
	}
}
