using Midnight.Engine.ActionManager;
using Midnight.Engine.ActionManager.Events;
using Midnight.Engine.Emitter;
using System.Collections.Generic;

namespace Midnight.Engine.Core
{
	public class Logger :
		IListener<Before<GameAction>>,
		IListener<Failure<GameAction>>
	{
		private List<GameAction> actions = new List<GameAction>();
		private List<GameAction> failures = new List<GameAction>();

		public Logger (EventEmitter emitter)
		{
			emitter.Subscribe(this);
		}

		public void On (Before<GameAction> e)
		{
			if (e.action.IsTop()) {
				actions.Add(e.action);
			}
		}

		public void On (Failure<GameAction> e)
		{
			failures.Add(e.action);
		}
	}
}
