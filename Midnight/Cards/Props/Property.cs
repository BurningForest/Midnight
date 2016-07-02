using System;
using Midnight.Cards.Enums;
using Sun.CardProtos;

namespace Midnight.Cards.Props
{
	public abstract class Property
	{
		public static Power     power     = new Power();
		public static Defense   defense   = new Defense();
		public static Toughness toughness = new Toughness();
		public static Increase  increase  = new Increase();
		public static Cost      cost      = new Cost();
		public static Damage    damage    = new Damage();

		public abstract int GetProtoValue (Proto proto);

		public class Power : Property
		{
			internal Power () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.Power ?? 0;
			}

			public override string ToString ()
			{
				return "power";
			}
		}
		public class Defense : Property
		{
			internal Defense () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.Defense ?? 0;
			}

			public override string ToString ()
			{
				return "defense";
			}
		}
		public class Toughness : Property
		{
			internal Toughness () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.Toughness ?? 0;
			}

			public override string ToString ()
			{
				return "toughness";
			}
		}
		public class Increase : Property
		{
			internal Increase () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.Increase ?? 0;
			}

			public override string ToString ()
			{
				return "increase";
			}
		}
		public class Cost : Property
		{
			internal Cost () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.Cost ?? 0;
			}

			public override string ToString ()
			{
				return "cost";
			}
		}
		public class Damage : Property
		{
			internal Damage () { }

			public override int GetProtoValue (Proto proto)
			{
				return 0;
			}

			public override string ToString ()
			{
				return "damage";
			}
		}
	}
}
