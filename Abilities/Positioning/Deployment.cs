using System;
using Midnight.Cards;
using Midnight.Core;
using Midnight.Battlefield;
using System.Collections.Generic;
using System.Linq;
using Midnight.Cards.Types;
using Midnight.Actions;

namespace Midnight.Abilities.Positioning
{
	public class Deployment : CardActiveAbility<ForefrontCard>
	{

		protected List<Cell> GetPotentialCells ()
		{
			return chief.GetFootholdCells();
		}

		protected bool IsCorrectCell (Cell cell)
		{
			return !cell.IsBusy();
		}

		public override Status Validate ()
		{
			return Validate(null);
		}

		public Status Validate (Cell cell)
		{
			if (!chief.IsTurnOwner()) {
				return Status.NotTurnOfSource;
			}

			if (!card.GetLocation().IsReserve()) {
				return Status.NotAtReserve;
			}

			if (cell != null && !IsAllowedCell(cell)) {
				return Status.CellIsNotAllowed;
			}

			return PayResources.ForCard(card).Validation();
		}

		public void Activate ()
		{
			var moveAbility = card.abilities.Get<Movement>();

			if (moveAbility != null) {
				moveAbility.Activate(false);
			}
		}

		public List<Cell> GetAllowedCells ()
		{
			return GetPotentialCells().Where(IsCorrectCell) as List<Cell>;
		}

		public bool IsAllowedCell (Cell cell)
		{
			return IsCorrectCell(cell) && GetPotentialCells().Contains(cell);
		}

		// todo: add resources pay action
	}
}
