using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Deployed : GameAction<Deployed>
	{
		public readonly ForefrontCard card;
		public readonly Cell cell;

		public Deployed (ForefrontCard card, Cell cell)
		{
			this.card = card;
			this.cell = cell;
		}

		public override void Configure ()
		{
			card.abilities.Get<Deployment>().Activate();

			if (card is Platoon) {
				((Platoon)card).GetLocation().ToSupport();
			} else {
				((FieldCard)card).GetFieldLocation().ToCell(cell);
			}

			AddChild(PayResources.ForCard(card));
			// add spotted
		}
	}
}
