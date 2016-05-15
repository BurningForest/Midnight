using Midnight.Engine.Battlefield;
using Midnight.Engine.Cards.Enums;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Cards
{
	public class CardFieldLocation : CardLocation
	{
		private Cell cell;
		protected new readonly FieldCard card;

		public CardFieldLocation (FieldCard card)
		{
			this.card = card;
		}

		public void ToCell (Cell cell)
		{
			RemoveCell();
			cell.SetCard(card);
			this.cell = cell;
			ToBattefield();
		}

		private void ToBattefield ()
		{
			location = Location.battlefield;
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

			cell.RemoveCard(card);
			cell = null;
		}
	}
}
