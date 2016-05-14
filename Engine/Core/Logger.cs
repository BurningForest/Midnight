using Midnight.Engine.ActionManager;
using Midnight.Engine.ActionManager.Events;
using Midnight.Engine.Emitter;
using System.Collections.Generic;

namespace Midnight.Engine.Core
{
	public class Logger :
		IListener<Before<Action>>,
		IListener<Failure<Action>>
	{
		private List<Action> actions = new List<Action>();
		private List<Action> failures = new List<Action>();

		public Logger (EventEmitter emitter)
		{
			emitter.Subscribe(this);
		}

		public void On (Before<Action> e)
		{
			if (e.action.IsTop()) {
				actions.Add(e.action);
			}
		}

		public void On (Failure<Action> e)
		{
			failures.Add(e.action);
		}
	}
}
