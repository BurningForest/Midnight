using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Core;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Deploy : GameAction<Deploy>
	{
		public readonly ForefrontCard Card;
		public readonly Cell Cell;

		public Deploy (ForefrontCard card, Cell cell)
		{
			Card = card;
			Cell = cell;
		}

		public override void Configure ()
		{
		    var platoon = Card as Platoon;
		    var previous = platoon?.GetChief().cards.GetPlatoonBySubtype(platoon.GetProto().Subtype);

		    if (previous != null)
		    {
		        AddChild(new Death.Forced(previous));
		    }

		    AddChild(new Deployed(Card, Cell));
		}

		public override Status Validation ()
		{
			var ability = Card.abilities.Get<Deployment>();

			return ability?.Validate(Cell) ?? Status.NoDeploymentAbility;
		}
	}
}
