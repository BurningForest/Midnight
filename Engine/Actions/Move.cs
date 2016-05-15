using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Cards;
using Midnight.Core;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Move : GameAction<Move>
	{
		private FieldCard card;
		private Cell cell;

		public Move (FieldCard card, Cell cell)
		{
			this.card = card;
			this.cell = cell;
		}

		public override void Configure ()
		{
			var moves = card.abilities.Get<Movement>().GetMovesTo(cell);

			foreach (var move in moves) {
				AddChild(new Step(card, move));
			}
		}

		public override Status Validation ()
		{
			var ability = card.abilities.Get<Movement>();

			if (ability == null) {
				return Status.NoMovementAbility;
			}

			return ability.Validate(cell);
		}
	}
}
