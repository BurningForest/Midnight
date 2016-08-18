using Midnight.Battlefield;
using Midnight.Cards.Types;

namespace Midnight.Cards
{
	public class CardFieldLocation : CardLocation
	{
		private Cell _cell;
		protected readonly FieldCard Card;

		public CardFieldLocation (FieldCard card)
		{
			Card = card;
		}

		public void ToCell (Cell cell)
		{
			RemoveCell();
			cell.SetCard(Card);
			_cell = cell;
			ToBattefield();
		}

		private void ToBattefield ()
		{
			Location = Enums.Location.Battlefield;
		}

		public Cell GetCell ()
		{
			return _cell;
		}

		public void RemoveCell ()
		{
			if (_cell == null) {
				return;
			}

			_cell.RemoveCard(Card);
			_cell = null;
		}

		public override void CloneFrom (CardLocation source)
		{
			base.CloneFrom(source);

		    if (!source.IsBattlefield()) return;
		    var cardFieldLocation = source as CardFieldLocation;
		    if (cardFieldLocation == null) return;
		    var cell = cardFieldLocation.GetCell();
		    ToCell(Card.GetChief().GetEngine().Field.GetCell(cell.X, cell.Y));
		}
	}
}
