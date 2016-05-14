using Midnight.Engine.Battlefield;

namespace Midnight.Engine.Cards.Types
{
	public abstract class FieldCard : ForefrontCard
	{
		private Cell cell;

		public void ToCell (Cell cell)
		{
			RemoveCell();
			cell.SetCard(this);
			this.cell = cell;
			location.ToBattefield();
		}

		public Cell GetCell ()
		{
			return cell;
		}

		public void RemoveCell ()
		{
			if (cell == null) {
				return;
			}

			cell.RemoveCard(this);
			cell = null;
		}


	}
}
