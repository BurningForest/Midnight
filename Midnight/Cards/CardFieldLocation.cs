using Midnight.Battlefield;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Cards
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
			location = Location.Battlefield;
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

		public override void CloneFrom (CardLocation source)
		{
			base.CloneFrom(source);

			if (source.IsBattlefield()) {
				var cell = (source as CardFieldLocation).GetCell();
				ToCell(card.GetChief().GetEngine().field.GetCell(cell.X, cell.Y));
			}
		}
	}
}
