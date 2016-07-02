using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class LTraktor : LightVehicle
	{
		public static readonly Proto proto = new Proto<LTraktor>() {
			id = "gv_leichttraktor",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Light,
			country = Country.Germany,

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