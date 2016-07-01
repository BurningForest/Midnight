using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Draw : GameAction<Draw>
	{
		public readonly Card card;

		public Draw (Card card)
		{
			this.card = card;
		}

		public override void Configure ()
		{
			card.GetLocation().ToReserve();
		}

		public override Status Validation ()
		{
			if (card == null) {
				return Status.NoCard;
			}

			if (!card.GetLocation().IsDeck()) {
				return Status.NotInDeck;
			}

			return Status.Success;
		}
	}
}
