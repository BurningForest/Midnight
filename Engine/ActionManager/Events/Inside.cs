namespace Midnight.ActionManager.Events
{
	public class Inside<TAction> : Event<Inside<TAction>, TAction>
		where TAction : GameAction
	{
		public Inside (TAction action) : base(action) { }
	}
}
