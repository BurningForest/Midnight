using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankSpatg : SpatgVehicle
	{
		public static readonly Proto proto = new Proto<TankSpatg>() {
			id = "tv_Spatg_tank",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Spatg,
			country = Country.Germany,

			power = 2,
			defense = 0,
			toughness = 2,
			increase = 0,
			cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}