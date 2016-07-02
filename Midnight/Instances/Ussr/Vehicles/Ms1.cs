using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Ms1 : LightVehicle
	{
		public static readonly Proto proto = new Proto<Ms1>() {
			id = "sv_ms1",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Light,
			country = Country.USSR,

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