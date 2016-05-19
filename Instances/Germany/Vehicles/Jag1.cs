using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Germany.Vehicle
{
	public class Jag1 : SpatgVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "gv_panzerjagerI",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.spatg,
			country = Country.germany,

			power = 3,
			defense = 0,
			toughness = 3,
			increase = 0,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}