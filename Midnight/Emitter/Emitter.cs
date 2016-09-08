using System.Collections.Generic;
using System.Linq;

namespace Midnight.Emitter
{
	public class EventEmitter
	{
		private readonly List<IListener> _listeners = new List<IListener>();

		public void Subscribe (IListener listener)
		{
			_listeners.Add(listener);
		}

		public void Publish<TEvent> (TEvent e)
			where TEvent : IEvent
		{
		    foreach (var l in _listeners.OfType<IListener<TEvent>>())
		    {
		        l.On(e);
		    }
		}
	}
}
