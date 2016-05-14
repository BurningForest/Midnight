namespace Midnight.Engine.ActionManager.Events
{
	public class Before<TAction> : Event<Before<TAction>, TAction>
		where TAction : GameAction
	{
		public Before (TAction action) : base(action) { }
	}
}
