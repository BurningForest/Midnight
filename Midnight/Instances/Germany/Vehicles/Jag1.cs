using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class Jag1 : SpatgVehicle
	{
		public static readonly Proto proto = new Proto<Jag1>() {
			id = "gv_panzerjagerI",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Spatg,
			country = Country.Germany,

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