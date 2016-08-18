using Midnight.Emitter;
using System.Collections.Generic;

namespace Midnight.ActionManager
{
	public class Manager
	{
		private readonly List<GameAction> _activeActions = new List<GameAction>();
		private readonly List<GameAction> _delayedActions = new List<GameAction>();
		private readonly Engine _engine;
        public EventEmitter Emitter { get; }

        public Manager (Engine engine)
		{
			_engine = engine;
			Emitter = engine.emitter;
		}

		public void Delay<TAction> (TAction action)
			where TAction : GameAction
		{
			if (IsIdle())
            {
				Launch(action);
			}
            else
            {
				_delayedActions.Add(action);
			}
		}

		internal void Register (GameAction action)
		{
			action.SetActionManager(this);
			action.SetEngine(_engine);
		}

		public bool Launch<TAction> (TAction action)
			where TAction : GameAction
		{
		    if (IsIdle())
            {
				return ForceLaunch(action);
			}
		    throw new System.Exception("Actions are running now");
		}

	    private bool ForceLaunch<TAction> (TAction action)
			where TAction : GameAction
		{
			Register(action);
			action.Validate();

			if (action.IsValid())
            {
				_activeActions.Add(action);
				LaunchRec(action);
				return true;
			}
	        action.NotifyFailure(Emitter);
	        return false;
		}

		public bool IsIdle ()
		{
			return _activeActions.Count == 0;
		}

		private void LaunchRec<TAction> (TAction action)
			where TAction : GameAction
		{
			action.NotifyBefore(Emitter);

			action.Configure();

			action.NotifyInside(Emitter);

			action.Close();

			foreach (var child in action.Children)
            {
				ForceLaunch(child);
			}

			action.Complete();

			action.NotifyAfter(Emitter);

			_activeActions.Remove(action);

			CheckFinish(action);
		}

		private void CheckFinish<TAction> (TAction action)
			where TAction : GameAction
		{
			if (!IsIdle())
            {
				return;
			}
			if (_delayedActions.Count > 0)
            {
				var first = _delayedActions[0];
				_delayedActions.Remove(first);
				Launch(first);
			}
            else
            {
				action.NotifyFinish(Emitter);
			}
		}
	}
}
