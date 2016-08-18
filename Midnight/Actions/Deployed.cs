using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Deployed : GameAction<Deployed>
	{
		public readonly ForefrontCard Card;
		public readonly Cell Cell;

		public Deployed (ForefrontCard card, Cell cell)
		{
			Card = card;
			Cell = cell;
		}

		public override void Configure ()
		{
			Card.abilities.Get<Deployment>().Activate();

		    var card = Card as Platoon;
		    if (card != null)
            {
				card.GetLocation().ToSupport();
			}
            else
            {
				((FieldCard)Card).GetFieldLocation().ToCell(Cell);
			}

			AddChild(PayResources.ForCard(Card));
			GetEngine().lantern.RecountTo(this);
		}
	}
}
