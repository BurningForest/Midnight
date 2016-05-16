using Midnight.Battlefield;
using System.Collections.Generic;

namespace Midnight.Cards.Types
{
	public abstract class FieldCard : ForefrontCard
	{
		private Cell cell;
		private CardFieldLocation location;

		public override CardLocation GetLocation ()
		{
			return GetFieldLocation();
		}

		public CardFieldLocation GetFieldLocation ()
		{
			if (location == null) {
				location = new CardFieldLocation(this);
			}

			return location;
		}

		public List<FieldCard> GetAdjoiningCards ()
		{
			var cells = location.GetCell().GetAdjoiningCells();

			return GetChief().GetEngine().field.GetCardsOf(cells);
		}

		public abstract bool IsSpotted ();
	}
}
