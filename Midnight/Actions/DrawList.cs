using Midnight.ActionManager;
using Midnight.Cards;
using System.Collections.Generic;

namespace Midnight.Actions
{
	public class DrawList : GameAction<DrawList>
	{
		public readonly IEnumerable<Card> Cards;

		public DrawList (IEnumerable<Card> cards)
		{
			Cards = cards;
		}

		public override void Configure ()
		{
			foreach (var card in Cards)
            {
				AddChild(new Draw(card));
			}
		}
	}
}
