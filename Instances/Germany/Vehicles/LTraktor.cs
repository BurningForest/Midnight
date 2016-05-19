using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Germany.Vehicle
{
	public class LTraktor : LightVehicle
	{
		public static readonly Proto proto = new Proto<LTraktor>() {
			id = "gv_leichttraktor",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.light,
			country = Country.germany,

			power = 2,
			defense = 0,
			toughness = 2,
			increase = 0,
			cost = 1,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}