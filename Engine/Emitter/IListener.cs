namespace Midnight.Emitter
{
	public interface IListener { }

	public interface IListener<TEvent> : IListener
	{
		void On (TEvent ev);
	}
}
