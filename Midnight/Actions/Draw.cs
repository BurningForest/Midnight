using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Draw : GameAction<Draw>
	{
		public readonly Card Card;

		public Draw (Card card)
		{
			Card = card;
		}

		public override void Configure ()
		{
			Card.GetLocation().ToReserve();
		}

		public override Status Validation ()
		{
			if (Card == null)
            {
				return Status.NoCard;
			}

			return !Card.GetLocation().IsDeck() ? Status.NotInDeck : Status.Success;
		}
	}
}
