using System;
using Midnight.Cards;
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
			quantity += cost;

			if (GetQuantity() > GetMaxQuantity()) {
				quantity = GetMaxQuantity();
			}
		}

		private int GetMoveCost (Cell cell)
		{
			var current = GetCard().GetFieldLocation().GetCell();

			if (current.IsRunTo(cell)) {
				return GetRunMoveCost();
			} else if (current.IsCornerTo(cell)) {
				return GetCornerMoveCost();
			} else if (current.IsCloseTo(cell)) {
				return GetCloseMoveCost();
			} else {
				return 0;
			}
		}

		public virtual bool CanMoveTo (Cell cell)
		{
			if (cell.IsBusy()) {
				return false;
			}

			int cost = GetMoveCost(cell);

			return cost > 0 && (quantity + cost) <= GetMaxQuantity();
		}

		public virtual Cell[] GetMovesTo (Cell cell)
		{
			return new Cell[] { cell };
		}

		public List<Cell> GetAllowedCells ()
		{
			return GetCard()
				.GetFieldLocation()
				.GetCell()
				.GetRunCells()
				.Where(CanMoveTo) as List<Cell>;
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

			if (!card.GetLocation().IsBattlefield()) {
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
			if (card.IsControlledBy(ev.action.chief)) {
				quantity = 0;
			}
		}
	}
}
