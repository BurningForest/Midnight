using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Tests.TestInstances
{
	public class TankSpatg : SpatgVehicle
	{
		public static readonly Proto proto = new Proto<TankSpatg>() {
			id = "tv_spatg_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.spatg,
			country = Country.germany,

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