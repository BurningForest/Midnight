namespace Emitter {
    public interface IListener { }

    public interface IAllListener
    {
        void On (IEvent e);
    }

    public interface IListener<TEvent>: IListener
        where TEvent : IEvent
    {
        void On (TEvent e);
    }
}