using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T1Light : LightVehicle
	{
		public static readonly Proto proto = new Proto<T1Light>() {
			id = "uv_t1lt",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Light,
			country = Country.USA,

			power = 2,
			defense = 0,
			toughness = 3,
			increase = 1,
			cost = 3,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}