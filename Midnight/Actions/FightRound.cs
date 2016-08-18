using Midnight.ActionManager;
using System.Collections.Generic;
using Midnight.Core;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class FightRound : GameAction<FightRound>
	{
		private readonly List<GameAction> _actions = new List<GameAction>();
		private readonly List<ForefrontCard> _cards = new List<ForefrontCard>();

		internal void AddFightAction(GameAction action, ForefrontCard card)
		{
			_actions.Add(action);
			_cards.Add(card);
		}

		public override void Configure ()
		{
			AddChildren(_actions);

			foreach (var card in _cards)
            {
				AddChild(new Death(card));
			}
		}

		public override Status Validation ()
		{
		    return _actions.Count == 0 ? Status.FightRoundIsEmpty : Status.Success;
		}
	}
}
