namespace Emitter
{
    public class Subscriber
    {
        EventEmitter emitter;
        IListener listener;

        public Subscriber (EventEmitter emitter, IListener listener)
        {
            this.emitter = emitter;
            this.listener = listener;
        }

        public Subscriber To<TEvent> ()
            where TEvent : IEvent
        {
            this.emitter.SubscribeTo<TEvent>(listener);
            return this;
        }
    }
}