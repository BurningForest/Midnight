using Midnight.Engine.ActionManager;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Cards;
using Midnight.Engine.Core;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Actions
{
	public class Position : Action<Position>
	{
		private FieldCard card;
		private Cell cell;

		public Position (FieldCard card, Cell cell)
		{
			this.card = card;
			this.cell = cell;
		}

		public override void Configure ()
		{
			card.ToCell(cell);

			// todo: spotted
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
