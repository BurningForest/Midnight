using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class T35_1 : HeavyVehicle
	{
		public static readonly Proto proto = new Proto<T24>() {
			id = "sv_t351",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Heavy,
			country = Country.USSR,

			power = 3,
			defense = 0,
			toughness = 9,
			increase = 1,
			cost = 6,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}