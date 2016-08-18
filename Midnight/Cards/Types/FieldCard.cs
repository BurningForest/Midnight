using Midnight.Battlefield;
using System.Collections.Generic;

namespace Midnight.Cards.Types
{
	public abstract class FieldCard : ForefrontCard
	{
		private Cell _cell;
		private CardFieldLocation _location;

		public override CardLocation GetLocation ()
		{
			return GetFieldLocation();
		}

		public CardFieldLocation GetFieldLocation ()
		{
			if (_location == null)
            {
				CreateLocation();
			}

			return _location;
		}

		public override void CreateLocation ()
		{
			_location = new CardFieldLocation(this);
		}

		public List<FieldCard> GetAdjoiningCards ()
		{
			var cells = _location.GetCell().GetAdjoiningCells();

			return GetChief().GetEngine().field.GetCardsOf(cells);
		}

		public abstract bool IsSpotted ();
	}
}
