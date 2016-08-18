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
		    if (base.CanMoveTo(cell) == false)
            {
				return false;
			}

		    return !HasMiddleCell(cell) || base.CanMoveTo(GetMiddleCell(cell));
		}

	    private bool HasMiddleCell (Cell cell)
		{
			return GetCard().GetFieldLocation().GetCell().IsRunTo(cell);
		}

		private Cell GetMiddleCell (Cell cell)
		{
			if (!HasMiddleCell(cell))
            {
				return null;
			}

			var current = GetCard().GetFieldLocation().GetCell();

			return Engine.field.GetCell(
				(current.x + cell.x) / 2,
				(current.y + cell.y) / 2
			);
		}

		public override Cell[] GetMovesTo (Cell cell)
		{
		    return HasMiddleCell(cell) ? new[] { GetMiddleCell(cell), cell } : new[] { cell };
		}
	}
}
