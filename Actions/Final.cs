﻿using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.ChiefOperations;
using System.Collections.Generic;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Final : GameAction<Final>
	{
		public enum Trigger
		{
			HqDeath,
			DeckOut,
			Surrender
		};

		public readonly Chief winner;
		public readonly Trigger trigger;

		public Final (Chief winner, Trigger trigger)
		{
			this.winner = winner;
			this.trigger = trigger;
		}

		public override void Configure ()
		{
			winner.GetEngine().Finish(this);
		}

		public override Status Validation ()
		{
			if (winner.GetEngine().final != null) {
				return Status.GameIsFinished;
			}

			return Status.Success;
		}
	}
}