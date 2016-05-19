using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T1Light : LightVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "uv_t1lt",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.light,
			country = Country.usa,

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