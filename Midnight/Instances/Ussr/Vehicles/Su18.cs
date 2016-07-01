using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Su18 : HeavyVehicle
	{
		public static readonly Proto proto = new Proto<Su18>() {
			id = "sv_su18",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.spg,
			country = Country.ussr,

			power = 1,
			defense = 0,
			toughness = 4,
			increase = 0,
			cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}