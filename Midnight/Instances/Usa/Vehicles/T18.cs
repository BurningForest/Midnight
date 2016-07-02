using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T18 : SpatgVehicle
	{
		public static readonly Proto proto = new Proto<T18>() {
			id = "uv_t18",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Spatg,
			country = Country.USA,

			power = 2,
			defense = 0,
			toughness = 5,
			increase = 0,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}