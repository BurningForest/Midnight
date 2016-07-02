using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankSpg : SpgVehicle
	{
		public static readonly Proto proto = new Proto<TankSpg>() {
			id = "tv_Spg_tank",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Spg,
			country = Country.USA,

			power = 1,
			defense = 0,
			toughness = 3,
			increase = 0,
			cost = 0,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}