using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Ms1 : LightVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "sv_ms1",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.light,
			country = Country.ussr,

			power = 1,
			defense = 0,
			toughness = 4,
			increase = 1,
			cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}