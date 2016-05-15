using Midnight.Engine.ActionManager;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Core;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Actions
{
	public class Deploy : GameAction<Deploy>
	{
		private ForefrontCard card;
		private Cell cell;

		public Deploy (ForefrontCard card, Cell cell)
		{
			this.card = card;
			this.cell = cell;
		}

		public override void Configure ()
		{
			if (card is Platoon) {
				var previous = card.GetChief().GetPlatoonBySubtype(card.GetProto().subtype);

				if (previous != null) {
					AddChild(new Death(previous));
				}
			}

			AddChild(new Deployed(card, cell));
		}

		public override Status Validation ()
		{
			var ability = card.abilities.Get<Deployment>();

			if (ability == null) {
				return Status.NoDeploymentAbility;
			}

			return ability.Validate(cell);
		}
	}
}
