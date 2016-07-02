using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class Liberty : HeavyVehicle
	{
		public static readonly Proto proto = new Proto<Liberty>() {
			id = "uv_mark7liberty",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Heavy,
			country = Country.USA,

			power = 4,
			defense = 0,
			toughness = 7,
			increase = 2,
			cost = 7,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}