using System;
using Midnight.Cards.Enums;

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
				return proto.power;
			}
		}
		public class Defense : Property
		{
			internal Defense () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.defense;
			}
		}
		public class Toughness : Property
		{
			internal Toughness () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.toughness;
			}
		}
		public class Increase : Property
		{
			internal Increase () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.increase;
			}
		}
		public class Cost : Property
		{
			internal Cost () { }

			public override int GetProtoValue (Proto proto)
			{
				return proto.cost;
			}
		}
		public class Damage : Property
		{
			internal Damage () { }

			public override int GetProtoValue (Proto proto)
			{
				return 0;
			}
		}
	}
}
