using System;
using Midnight.ActionManager;
using System.Collections.Generic;
using Midnight.Core;

namespace Midnight.Actions
{
	public class FightRound : GameAction<FightRound>
	{
		private List<GameAction> actions = new List<GameAction>();

		internal void AddFightAction(GameAction action)
		{
			actions.Add(action);
		}

		public override void Configure ()
		{
			AddChildren(actions);

			// todo: death
		}

		public override Status Validation ()
		{
			if (actions.Count == 0) {
				return Status.FightRoundIsEmpty;
			}

			return Status.Success;
		}
	}
}
