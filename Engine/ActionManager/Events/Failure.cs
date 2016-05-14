namespace Midnight.Engine.ActionManager.Events
{
	public class Failure<TAction> : Event<Failure<TAction>, TAction>
		where TAction : GameAction
	{
		public Failure (TAction action) : base(action) { }
	}
}
