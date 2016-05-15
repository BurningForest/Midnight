using Midnight.Engine.Battlefield;

namespace Midnight.Engine.Cards.Types
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
	}
}
