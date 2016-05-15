using System;
using Midnight.Battlefield;

namespace Midnight.Abilities.Positioning
{
	public class MovementFast : Movement
	{
		public override int GetMaxQuantity ()
		{
			return 4;
		}

		public override bool CanMoveTo (Cell cell)
		{
			if (base.CanMoveTo(cell) == false) {
				return false;
			}

			if (HasMiddleCell(cell)) {
				return base.CanMoveTo(GetMiddleCell(cell));
			} else {
				return true;
			}
		}

		private bool HasMiddleCell (Cell cell)
		{
			return GetCard().GetFieldLocation().GetCell().IsRunTo(cell);
		}

		private Cell GetMiddleCell (Cell cell)
		{
			if (!HasMiddleCell(cell)) {
				return null;
			}

			var current = GetCard().GetFieldLocation().GetCell();

			return engine.field.GetCell(
				(current.x + cell.x) / 2,
				(current.y + cell.y) / 2
			);
		}

		public override Cell[] GetMovesTo (Cell cell)
		{
			if (HasMiddleCell(cell)) {
				return new Cell[] { GetMiddleCell(cell), cell };
			} else {
				return new Cell[] { cell };
			}
		}
	}
}
