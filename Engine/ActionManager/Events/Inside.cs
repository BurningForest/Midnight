namespace Midnight.Engine.ActionManager.Events
{
	public class Inside<TAction> : Event<Inside<TAction>, TAction>
		where TAction : GameAction
	{
		public Inside (TAction action) : base(action) { }
	}
}
