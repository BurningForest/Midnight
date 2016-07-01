using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Cards;
using Midnight.Core;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Position : GameAction<Position>
	{
		public readonly FieldCard card;
		public readonly Cell cell;

		public Position (FieldCard card, Cell cell)
		{
			this.card = card;
			this.cell = cell;
		}

		public override void Configure ()
		{
			card.GetFieldLocation().ToCell(cell);
			GetEngine().lantern.RecountTo(this);
		}

		public override Status Validation ()
		{
			if (cell.IsBusy()) {
				return Status.NoMovementAbility;
			}

			return Status.Success;
		}
	}
}
