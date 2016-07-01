using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T7Combat : LightVehicle
	{
		public static readonly Proto proto = new Proto<T7Combat>() {
			id = "uv_t7combatcar",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.light,
			country = Country.usa,

			power = 3,
			defense = 0,
			toughness = 1,
			increase = 0,
			cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}