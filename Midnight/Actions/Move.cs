using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Core;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Move : GameAction<Move>
	{
		public readonly FieldCard Card;
		public readonly Cell Cell;

		public Move (FieldCard card, Cell cell)
		{
			Card = card;
			Cell = cell;
		}

		public override void Configure ()
		{
			var moves = Card.abilities.Get<Movement>().GetMovesTo(Cell);

			foreach (var move in moves)
            {
				AddChild(new Step(Card, move));
			}
		}

		public override Status Validation ()
		{
			var ability = Card.abilities.Get<Movement>();

			return ability?.Validate(Cell) ?? Status.NoMovementAbility;
		}
	}
}
