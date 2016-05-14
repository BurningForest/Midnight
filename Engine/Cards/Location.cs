namespace Midnight.Engine.Cards
{
	public class Location
	{
		public static readonly Location battlefield = new Location();
		public static readonly Location graveyard = new Location();
		public static readonly Location support = new Location();
		public static readonly Location reserve = new Location();
		public static readonly Location deck = new Location();

		private Location () { }
	}
}
