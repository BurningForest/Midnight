using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class A7v : HeavyVehicle
	{
		public static readonly Proto proto = new Proto<A7v>() {
			id = "gv_a7v",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Heavy,
			country = Country.Germany,

			power = 2,
			defense = 0,
			toughness = 8,
			increase = 1,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}