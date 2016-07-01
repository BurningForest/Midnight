using Midnight.Emitter;
using System.Collections.Generic;
using Midnight.ActionManager.Events;
using Midnight.Actions;
using System;

namespace Midnight.ActionManager
{
	public class Manager
	{
		private List<GameAction> activeActions = new List<GameAction>();
		private List<GameAction> delayedActions = new List<GameAction>();
		public readonly EventEmitter emitter;
		private readonly Engine engine;

		public Manager (Engine engine)
		{
			this.engine = engine;
			emitter = engine.emitter;
		}

		public void Delay<TAction> (TAction action)
			where TAction : GameAction
		{
			if (IsIdle()) {
				Launch(action);
			} else {
				delayedActions.Add(action);
			}
		}

		internal void Register (GameAction action)
		{
			action.SetActionManager(this);
			action.SetEngine(engine);
		}

		public bool Launch<TAction> (TAction action)
			where TAction : GameAction
		{
			if (IsIdle()) {
				return ForceLaunch(action);
			} else {
				throw new System.Exception("Actions are running now");
			}
		}

		private bool ForceLaunch<TAction> (TAction action)
			where TAction : GameAction
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
			where TAction : GameAction
		{
			action.NotifyBefore(emitter);

			action.Configure();

			action.NotifyInside(emitter);

			action.Close();

			foreach (GameAction child in action.GetChildren()) {
				ForceLaunch(child);
			}

			action.Complete();

			action.NotifyAfter(emitter);

			activeActions.Remove(action);

			CheckFinish(action);
		}

		private void CheckFinish<TAction> (TAction action)
			where TAction : GameAction
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
