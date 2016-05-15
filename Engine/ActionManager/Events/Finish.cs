namespace Midnight.ActionManager.Events
{
	public class Finish<TAction> : Event<Finish<TAction>, TAction>
		where TAction : GameAction
	{
		public Finish (TAction action) : base(action) { }
	}
}
