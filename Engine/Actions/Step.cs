﻿using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.ActionManager;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Cards;

namespace Midnight.Engine.Actions
{
	public class Step : Action<Step>
	{
		private FieldCard card;
		private Cell cell;

		public Step (FieldCard card, Cell cell)
		{
			this.card = card;
			this.cell = cell;
		}

		public override void Configure ()
		{
			card.GetActiveAbility<Movement>().Activate(cell);
			card.ToCell(cell);
			
			// todo: spotted
		}
	}
}
