using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Tests.TestInstances
{
	public class TankHeavy : HeavyVehicle
	{
		public static readonly Proto proto = new Proto<TankHeavy>() {
			id = "tv_medium_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.heavy,
			country = Country.ussr,

			power = 3,
			defense = 0,
			toughness = 9,
			increase = 2,
			cost = 6,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}