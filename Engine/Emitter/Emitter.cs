using Midnight.Engine.ActionManager.Events;
using Midnight.Engine.Actions;
using System.Collections.Generic;

namespace Midnight.Engine.Emitter
{
	public class EventEmitter
	{
		private List<IListener> listeners = new List<IListener>();

		public void Subscribe (IListener listener)
		{
			listeners.Add(listener);
		}

		public void Publish<TEvent> (TEvent e)
			where TEvent : IEvent
		{
			foreach (var l in listeners) {
				if (l is IListener<TEvent>) {
					(l as IListener<TEvent>).On(e);
				}
			}
		}
	}
}
