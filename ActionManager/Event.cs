using Midnight.Emitter;

namespace Midnight.ActionManager
{
	public abstract class Event<TEvent, TAction> : IEvent
		where TEvent : Event<TEvent, TAction>
		where TAction : GameAction
	{
		public readonly TAction action;

		public Event (TAction action)
		{
			this.action = action;
		}
	}
}
