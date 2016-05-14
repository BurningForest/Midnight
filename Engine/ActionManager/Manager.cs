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

		public void Delay (Action action)
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
				emitter.Publish(new Failure<TAction>(action));
				emitter.Publish(new Failure<Action>(action));
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
			emitter.Publish(new Before<TAction>(action));
			emitter.Publish(new Before<Action>(action));

			action.Configure();

			emitter.Publish(new Inside<TAction>(action));
			emitter.Publish(new Inside<Action>(action));

			action.Close();

			foreach (Action child in action.GetChildren()) {
				ForceLaunch(child);
			}

			action.Complete();
			activeActions.Remove(action);

			emitter.Publish(new After<TAction>(action));
			emitter.Publish(new After<Action>(action));

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
				emitter.Publish(new Finish<TAction>(action));
				emitter.Publish(new Finish<Action>(action));
			}
		}
	}
}
