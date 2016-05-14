using System;
using Midnight.Engine.Cards;
using Midnight.Engine.Emitter;
using Midnight.Engine.Battlefield;
using System.Collections.Generic;
using System.Linq;
using Midnight.Engine.Core;
using Midnight.Engine.ActionManager.Events;
using Midnight.Engine.Actions;

namespace Midnight.Engine.Abilities.Positioning
{
	public abstract class Movement : CardActiveAbility<FieldCard>, IListener<Before<BeginTurn>>
	{
		public int GetRunMoveCost    () { return 4; }
		public int GetCornerMoveCost () { return 3; }
		public int GetCloseMoveCost  () { return 2; }

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
			var current = GetCard().GetCell();

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
			return new Cell[]{ cell };
		}

		public List<Cell> GetAllowedCells ()
		{
			return (List<Cell>) GetCard()
				.GetCell()
				.GetRunCells()
				.Where(CanMoveTo);
		}

		public override Status Validate ()
		{
			if (!chief.IsTurnOwner()) {
				return Status.NotTurnOfSource;
			}

			if (!card.IsAtBattlefield()) {
				return Status.NotAtBattlefield;
			}

			if (IsUsed()) {
				return Status.PointsAreUsed;
			}

			return Status.Success;
		}

		public Status Validate (Cell cell)
		{
			var status = Validate();

			if (status != Status.Success) {
				return status;
			}

			if (cell != null && !CanMoveTo(cell)) {
				return Status.PointsNotEnough;
			}

			return Status.Success;
		}
        
		public void On(Before<BeginTurn> ev)
		{
			if (card.IsControlledBy(ev.action.chief)) {
				quantity = 0;
			}
		}
	}
}
