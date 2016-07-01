using System;
using Midnight.ActionManager;
using System.Collections.Generic;
using Midnight.Core;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class FightRound : GameAction<FightRound>
	{
		private List<GameAction> actions = new List<GameAction>();
		private List<ForefrontCard> cards = new List<ForefrontCard>();

		internal void AddFightAction(GameAction action, ForefrontCard card)
		{
			actions.Add(action);
			cards.Add(card);
		}

		public override void Configure ()
		{
			AddChildren(actions);

			foreach (var card in cards) {
				AddChild(new Death(card));
			}
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
