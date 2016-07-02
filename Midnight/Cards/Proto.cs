using Sun.CardProtos.Enums;

namespace Midnight.Cards.Enums
{
	public abstract class Proto
	{
		public string id;
		public int level;
		public Type type;
		public Subtype subtype;
		public Country country;

		public int power;
		public int defense;
		public int toughness;
		public int increase;
		public int cost;

		public abstract Card Produce ();
	}

	public class Proto<TCard> : Proto
		where TCard : Card, new()
	{
		public override Card Produce ()
		{
			return new TCard();
		}
	}
}
