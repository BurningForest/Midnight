namespace Midnight.Engine.ActionManager.Events
{
	public class Finish<TAction> : Event<Finish<TAction>, TAction>
		where TAction : Action
	{
		public Finish (TAction action) : base(action) { }
	}
}
