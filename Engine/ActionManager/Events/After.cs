namespace Midnight.Engine.ActionManager.Events
{
	public class After<TAction> : Event<After<TAction>, TAction>
		where TAction : GameAction
	{
		public After (TAction action) : base(action) { }
	}
}
