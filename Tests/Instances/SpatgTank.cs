using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Tests.Instances
{
	public class SpatgTank : SpatgVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "tv_spatg_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.spatg,
			country = Country.germany,

			power = 2,
			defense = 0,
			toughness = 3,
			increase = 0,
			cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}