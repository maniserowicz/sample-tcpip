using System;
using System.Collections.Generic;
using Procent.Samples.TcpIp.Common.Messages;

namespace Procent.Samples.TcpIp.Common
{
	/// <summary>
	/// A container of all handlers responsible for handling incoming messages.
	/// </summary>
	public static class MessageHandlerManager
	{
		private static readonly Dictionary<Type, IMessageHandler> _handlers = new Dictionary<Type, IMessageHandler>();

		/// <summary>
		/// Registers a handler for a given type of Message.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when a handler for a given Message type has already been registered.</exception>
		public static void RegisterHandler<T>(IMessageHandler handler) where T : MessageBase
		{
			Type type = typeof(T);

			if (_handlers.ContainsKey(type))
				throw new InvalidOperationException("Handler already registered for this message type!");

			_handlers.Add(type, handler);
		}

		/// <summary>
		/// Registers a handler for a given type of Message. If a handler already exists - it is replaced.
		/// </summary>
		/// <remarks>May be used to replace default handlers.</remarks>
		public static void ForceRegisterHandler<T>(IMessageHandler handler) where T : MessageBase
		{
			Type type = typeof(T);

			if (_handlers.ContainsKey(type))
				_handlers.Remove(type);

			_handlers.Add(type, handler);
		}

		/// <summary>
		/// Delegates the handling request to a previously registered handler.
		/// </summary>
		/// <param name="receiver">Object that received the message.</param>
		/// <param name="message"></param>
		public static void HandleMessage(object receiver, MessageBase message)
		{
			_handlers[message.GetType()].HandleMessage(receiver, message);
		}

		/// <summary>
		/// Gets a handler registered for a given message type.
		/// </summary>
		/// <returns>A handler registered for a given message type or a null reference.</returns>
		/// <remarks>May be used to configure handlers during runtime.</remarks>
		public static IMessageHandler GetHandler<T>() where T : MessageBase
		{
			Type type = typeof(T);

			if (_handlers.ContainsKey(type))
				return _handlers[type];

			return null;
		}
	}
}