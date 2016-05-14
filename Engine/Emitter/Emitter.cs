using System;
using System.Collections.Generic;
using System.Reflection;
using Midnight.Engine.Core;

namespace Midnight.Engine.Emitter
{
	public class EventEmitter
	{
		private Dictionary<Type, List<Subscription>> listeners = new Dictionary<Type, List<Subscription>>();

		public EventEmitter Subscribe (IListener listener)
		{
			foreach (var method in listener.GetType().GetMethods()) {
				if (MethodHasSubscribe(method)) {
					ProcessMethod(listener, method);
				}
			}

			return this;
		}

		private bool MethodHasSubscribe (MethodInfo method)
		{
			foreach (var attr in method.GetCustomAttributes(true)) {
				if (attr is Subscribe) {
					return true;
				}
			}

			return false;
		}

		private void ProcessMethod (IListener listener, MethodInfo method)
		{
			var parameters = method.GetParameters();

			if (parameters.Length != 1) {
				throw new ArgumentException("Method should have only one param");
			}

			var type = parameters[0].ParameterType;

			if ( !typeof(IEvent).IsAssignableFrom(type) ) {
				throw new ArgumentException("First param of subscription should implements `IEvent`");
			}

			if (!listeners.ContainsKey(type)) {
				listeners.Add(type, new List<Subscription>());
			}

			listeners[type].Add(new Subscription() {
				listener = listener,
				method = method
			});
		}

		public void Publish(IEvent e)
		{
			Type type = e.GetType();

			if (listeners.ContainsKey(type)) {
				foreach (Subscription sub in listeners[type]) {
					sub.method.Invoke(sub.listener, new object[] { e });
				}
			}
		}
	}
}
