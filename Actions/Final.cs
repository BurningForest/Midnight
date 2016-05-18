using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.ChiefOperations;
using System.Collections.Generic;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Final : GameAction<Final>
	{
		public readonly Chief winner;

		public Final (Chief winner)
		{
			this.winner = winner;
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
