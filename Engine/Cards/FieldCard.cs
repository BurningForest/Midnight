using Midnight.Engine.Battlefield;
using System;

namespace Midnight.Engine.Cards
{
	public abstract class FieldCard : ForefrontCard
	{
		private Cell cell;

		public void ToCell (Cell cell)
		{
			RemoveCell();
			cell.SetCard(this);
			this.cell = cell;
			ToLocation(Location.battlefield);
		}

		public override void ToLocation (Location target)
		{
			if (target == Location.battlefield && cell == null) {
				throw new Exception("Use `ToCell` to position card on battlefield");
			}

			if (target != Location.battlefield) {
				RemoveCell();
			}

			base.ToLocation(target);
		}

		public Cell GetCell()
		{
			return cell;
		}

		public void RemoveCell()
		{
			if (cell == null) {
				return;
			}

			cell.RemoveCard(this);
			cell = null;
		}


	}
}
