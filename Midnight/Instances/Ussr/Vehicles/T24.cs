using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class T24 : HeavyVehicle
	{
		public static readonly Proto proto = new Proto<T24>() {
			id = "sv_t24",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Medium,
			country = Country.USSR,

			power = 1,
			defense = 0,
			toughness = 9,
			increase = 1,
			cost = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}