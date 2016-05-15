using Midnight.ActionManager;
using Midnight.ActionManager.Events;
using Midnight.Emitter;
using System;
using System.Collections.Generic;

namespace Midnight.Core
{
	public class Logger :
		IListener<Before<GameAction>>,
		IListener<Failure<GameAction>>
	{
		private List<GameAction> actions = new List<GameAction>();
		private List<GameAction> failures = new List<GameAction>();

		public Logger (Engine engine)
		{
			engine.emitter.Subscribe(this);
		}

		public void On (Before<GameAction> e)
		{
			if (e.action.IsTop()) {
				actions.Add(e.action);
			}

			Log(e.action);
		}

		private void Log (GameAction action)
		{
			var prefix = Repeat("| ", CountDepth(action));
			var name = action.GetType().Name;
			var status = "";

			if (action.GetStatus() != Status.Success) {
				name = "[" + name + "]";
				status = " (" + action.GetStatus() + ")";
			}

			Console.WriteLine(prefix + name + status); 
		}

		private string Repeat (string str, int count)
		{
			var result = "";

			while (count-- > 0) result += str;

			return result;
		}

		private int CountDepth (GameAction action)
		{
			int num = 0;

			while (!action.IsTop()) {
				++num;
				action = action.GetParent();
			}

			return num;
		}

		public void On (Failure<GameAction> e)
		{
			failures.Add(e.action);
			Log(e.action);
		}
	}
}
