using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.ChiefOperations;
using System.Collections.Generic;

namespace Midnight.Actions
{
	public class DrawList : GameAction<DrawList>
	{
		public readonly IEnumerable<Card> cards;

		public DrawList (IEnumerable<Card> cards)
		{
			this.cards = cards;
		}

		public override void Configure ()
		{
			foreach (var card in cards) {
				AddChild(new Draw(card));
			}
		}
	}
}
