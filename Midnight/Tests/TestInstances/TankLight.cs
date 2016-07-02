using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankLight : LightVehicle
	{
		public static readonly Proto proto = new Proto<TankLight>() {
			id = "tv_Light_tank",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Light,
			country = Country.USA,

			power = 1,
			defense = 0,
			toughness = 2,
			increase = 1,
			cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}