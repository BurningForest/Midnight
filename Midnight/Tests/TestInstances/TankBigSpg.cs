using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankBigSpg : SpgVehicle
	{
		public static readonly Proto proto = new Proto<TankBigSpg>() {
			id = "tv_big_Spg_tank",
			level = 5,
			type = Type.Vehicle,
			subtype = Subtype.Spg,
			country = Country.Germany,

			power = 8,
			defense = 0,
			toughness = 4,
			increase = 0,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}