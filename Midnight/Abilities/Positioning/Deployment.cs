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
			return Chief.GetFootholdCells();
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
			if (!Chief.IsTurnOwner())
            {
				return Status.NotTurnOfSource;
			}

			if (!Card.GetLocation().IsReserve())
            {
				return Status.NotAtReserve;
			}

			if (cell != null && !IsAllowedCell(cell))
            {
				return Status.CellIsNotAllowed;
			}

			return PayResources.ForCard(Card).Validation();
		}

		public void Activate ()
		{
			var moveAbility = Card.abilities.Get<Movement>();

		    moveAbility?.Activate(false);
		}

		public bool IsWithoutCell ()
		{
		    return Card.GetType() == typeof (Platoon);
        }

	    public List<Cell> GetAllowedCells ()
	    {
	        return IsWithoutCell() ? null : GetPotentialCells().Where(IsCorrectCell).ToList();
	    }

	    public bool IsAllowedCell (Cell cell)
		{
			return IsCorrectCell(cell) && GetPotentialCells().Contains(cell);
		}
	}
}
