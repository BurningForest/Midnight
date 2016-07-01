namespace Midnight.Cards.Enums
{
	public class Location
	{
		public static readonly Location battlefield = new Location("battlefield");
		public static readonly Location graveyard = new Location("graveyard");
		public static readonly Location support = new Location("support");
		public static readonly Location reserve = new Location("reserve");
		public static readonly Location deck = new Location("deck");

		public readonly string title;

		private Location (string title)
		{
			this.title = title;
		}

		public override string ToString ()
		{
			return "Location[" + title + "]";
		}
	}
}
