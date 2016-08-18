using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Core;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Position : GameAction<Position>
	{
		public readonly FieldCard Card;
		public readonly Cell Cell;

		public Position (FieldCard card, Cell cell)
		{
			Card = card;
			Cell = cell;
		}

		public override void Configure ()
		{
			Card.GetFieldLocation().ToCell(Cell);
			GetEngine().lantern.RecountTo(this);
		}

		public override Status Validation ()
		{
		    return Cell.IsBusy() ? Status.NoMovementAbility : Status.Success;
		}
	}
}
