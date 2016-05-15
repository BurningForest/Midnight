using System;
using System.Collections.Generic;

namespace Emitter
{
    public class EventEmitter
    {

        private Dictionary<Type, List<IListener>> listeners = new Dictionary<Type, List<IListener>>();
        private List<IAllListener> allListeners = new List<IAllListener>();
        private Dictionary<Type, IEvent> supportedEvents = new Dictionary<Type, IEvent>();

        public Subscriber Subscribe (IListener listener)
        {
            return new Subscriber(this, listener);
        }

        public EventEmitter AddSupport<TEvent> (TEvent e)
            where TEvent : IEvent
        {
            Type type = typeof(TEvent);
            listeners.Add(type, new List<IListener>());
            supportedEvents.Add(type, e);
            return this;
        }

        internal void SubscribeTo<TEvent> (IListener listener)
            where TEvent : IEvent
        {
            Type type = typeof(TEvent);
            IEvent validator;

            if (!supportedEvents.TryGetValue(type, out validator)) {
                throw new ArgumentException("Event [" + type + "] is not supported");
            }

            if (!validator.IsValidListener(listener)) {
                throw new ArgumentException("Listener [" + listener + "] does not support event [" + type + "]");
            }

            if (listeners[type].Contains(listener)) {
                throw new ArgumentException("Listener [" + listener + "] is already subscribed to [" + type + "]");
            }

            listeners[type].Add(listener);
        }

        public void SubscribeToAll (IAllListener listener)
        {

            if (allListeners.Contains(listener)) {
                throw new ArgumentException("Listener [" + listener + "] is already subscribed all");
            }

            allListeners.Add(listener);
        }

        public void Publish<TEvent> (TEvent e)
            where TEvent : IEvent
        {
            Type type = typeof(TEvent);

            foreach (IListener listener in listeners[type]) {
                e.Notify(listener);
            }

            foreach (IAllListener listener in allListeners) {
                listener.On(e);
            }
        }
    }
}
