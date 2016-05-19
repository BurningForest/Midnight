using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Germany.Vehicle
{
	public class A7v : HeavyVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "gv_a7v",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.heavy,
			country = Country.germany,

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