using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class T24 : HeavyVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "sv_t24",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.medium,
			country = Country.ussr,

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