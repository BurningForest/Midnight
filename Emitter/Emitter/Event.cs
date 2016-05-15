namespace Emitter {
    public interface IEvent {
        void Notify (IListener listener);
        bool IsValidListener (IListener listener);
    }

    public abstract class Event<TListener, TThisEvent> : IEvent
        where TListener : IListener<TThisEvent>
        where TThisEvent : Event<TListener, TThisEvent>
    {
        public bool IsValidListener (IListener listener) {
            return listener is TListener;
        }

        public void Notify (IListener listener) {
            Notify((TListener)listener);
        }

        public void Notify (TListener listener) {
            listener.On((TThisEvent)this);
        }
    }
}