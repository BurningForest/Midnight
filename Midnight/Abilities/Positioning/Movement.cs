using Midnight.Emitter;
using Midnight.Battlefield;
using System.Collections.Generic;
using System.Linq;
using Midnight.Core;
using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Cards.Types;

namespace Midnight.Abilities.Positioning
{
	public abstract class Movement : CardActiveAbility<FieldCard>, IListener<Before<BeginTurn>>
	{
		public int GetRunMoveCost () { return 4; }
		public int GetCornerMoveCost () { return 3; }
		public int GetCloseMoveCost () { return 2; }

		public int GetMinimalMoveCost ()
		{
			return GetCloseMoveCost();
		}

		public override bool IsUsed ()
		{
			return (GetQuantity() + GetMinimalMoveCost()) > GetMaxQuantity();
		}

		public void Activate (Cell cell)
		{
			Pay(GetMoveCost(cell));
		}

		public void Activate (bool max)
		{
			Pay(max ? GetMaxQuantity() : GetCloseMoveCost());
		}

		private void Pay (int cost)
		{
			Quantity += cost;

			if (GetQuantity() > GetMaxQuantity())
            {
				Quantity = GetMaxQuantity();
			}
		}

		private int GetMoveCost (Cell cell)
		{
			var current = GetCard().GetFieldLocation().GetCell();

			if (current.IsRunTo(cell))
            {
				return GetRunMoveCost();
			}
		    if (current.IsCornerTo(cell))
            {
		        return GetCornerMoveCost();
		    }
		    return current.IsCloseTo(cell) ? GetCloseMoveCost() : 0;
		}

		public virtual bool CanMoveTo (Cell cell)
		{
			if (cell.IsBusy())
            {
				return false;
			}

			int cost = GetMoveCost(cell);

			return cost > 0 && (Quantity + cost) <= GetMaxQuantity();
		}

		public virtual Cell[] GetMovesTo (Cell cell)
		{
			return new[] { cell };
		}

		public List<Cell> GetAllowedCells ()
		{
			return GetCard()
				.GetFieldLocation()
				.GetCell()
				.GetRunCells()
				.Where(CanMoveTo)
				.ToList();
		}

		public override Status Validate ()
		{
			return Validate(null);
		}

		public Status Validate (Cell cell)
		{
			if (!Chief.IsTurnOwner()) {
				return Status.NotTurnOfSource;
			}

			if (!Card.GetLocation().IsBattlefield()) {
				return Status.NotAtBattlefield;
			}

			if (IsUsed()) {
				return Status.PointsAreUsed;
			}

			if (cell != null && !CanMoveTo(cell)) {
				return Status.CellIsNotAllowed;
			}

			return Status.Success;
		}

		public void On (Before<BeginTurn> ev)
		{
			if (Card.IsControlledBy(ev.action.chief))
            {
				Quantity = 0;
			}
		}
	}
}
