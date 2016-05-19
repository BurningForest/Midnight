using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T18 : SpatgVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "uv_t18",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.spatg,
			country = Country.usa,

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