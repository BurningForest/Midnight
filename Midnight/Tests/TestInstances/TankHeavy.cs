using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankHeavy : HeavyVehicle
	{
		public static readonly Proto proto = new Proto<TankHeavy>() {
			id = "tv_Medium_tank",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Heavy,
			country = Country.USSR,

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