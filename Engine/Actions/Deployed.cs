using Midnight.Engine.ActionManager;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Cards;
using Midnight.Engine.Core;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Actions
{
	public class Deployed : GameAction<Deployed>
	{
		private ForefrontCard card;
		private Cell cell;

		public Deployed (ForefrontCard card, Cell cell)
		{
			this.card = card;
			this.cell = cell;
		}

		public override void Configure ()
		{
			card.abilities.Get<Deployment>().Activate();

			if (card is Platoon) {
				((Platoon)card).location.ToSupport();
			} else {
				((FieldCard)card).ToCell(cell);
			}

			// todo: Add PayResoures action
			// add spotted
		}
	}
}
