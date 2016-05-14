using Midnight.Engine.ActionManager;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Cards;
using Midnight.Engine.Core;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Actions
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
