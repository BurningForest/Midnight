using Midnight.Battlefield;
using System.Collections.Generic;
using Midnight.ChiefOperations;

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
				CreateLocation();
			}

			return location;
		}

		public override void CreateLocation ()
		{
			location = new CardFieldLocation(this);
		}

		public List<FieldCard> GetAdjoiningCards ()
		{
			var cells = location.GetCell().GetAdjoiningCells();

			return GetChief().GetEngine().field.GetCardsOf(cells);
		}

		public abstract bool IsSpotted ();
	}
}
