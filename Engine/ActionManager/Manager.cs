using Midnight.Engine.Emitter;
using System.Collections.Generic;
using Midnight.Engine.ActionManager.Events;
using Midnight.Engine.Actions;

namespace Midnight.Engine.ActionManager
{
	public class Manager
	{
		private List<Action> activeActions = new List<Action>();
		private List<Action> delayedActions = new List<Action>();
		public readonly EventEmitter emitter;
		private readonly Engine engine;

		public Manager (Engine engine)
		{
			this.engine = engine;
			emitter = engine.emitter;
		}

		public void Delay<TAction> (TAction action)
			where TAction : Action
		{
			if (IsIdle()) {
				Launch(action);
			} else {
				delayedActions.Add(action);
			}
		}

		internal void Register (Action action)
		{
			action.SetActionManager(this);
			action.SetEngine(engine);
		}

		public bool Launch<TAction> (TAction action)
			where TAction : Action
		{
			if (IsIdle()) {
				return ForceLaunch(action);
			} else {
				throw new System.Exception("Actions are running now");
			}
		}

		private bool ForceLaunch<TAction> (TAction action)
			where TAction : Action
		{
			Register(action);
			action.Validate();

			if (action.IsValid()) {
				activeActions.Add(action);
				LaunchRec(action);
				return true;
			} else {
				action.NotifyFailure(emitter);
				return false;
			}
		}

		public bool IsIdle ()
		{
			return activeActions.Count == 0;
		}

		private void LaunchRec<TAction> (TAction action)
			where TAction : Action
		{
			action.NotifyBefore(emitter);

			action.Configure();

			action.NotifyInside(emitter);

			action.Close();

			foreach (Action child in action.GetChildren()) {
				ForceLaunch(child);
			}

			action.Complete();

			action.NotifyAfter(emitter);

			activeActions.Remove(action);

			CheckFinish(action);
		}

		private void CheckFinish<TAction> (TAction action)
			where TAction : Action
		{
			if (!IsIdle()) {
				return;
			}
			if (delayedActions.Count > 0) {
				var first = delayedActions[0];
				delayedActions.Remove(first);
				Launch(first);
			} else {
				action.NotifyFinish(emitter);
			}
		}
	}
}
