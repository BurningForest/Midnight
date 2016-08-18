using Midnight.Abilities.Positioning;
using Midnight.ActionManager;
using Midnight.Battlefield;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Step : GameAction<Step>
	{
		public readonly FieldCard Card;
		public readonly Cell Cell;

		public Step (FieldCard card, Cell cell)
		{
			Card = card;
			Cell = cell;
		}

		public override void Configure ()
		{
			Card.Abilities.Get<Movement>().Activate(Cell);
			Card.GetFieldLocation().ToCell(Cell);
			GetEngine().Lantern.RecountTo(this);
		}
	}
}
