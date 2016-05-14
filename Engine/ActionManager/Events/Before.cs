namespace Midnight.Engine.ActionManager.Events
{
	public class Before<TAction> : Event<Before<TAction>, TAction>
		where TAction : Action
	{
		public Before (TAction action) : base(action) { }
	}
}
