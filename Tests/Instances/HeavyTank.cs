using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Tests.Instances
{
	public class HeavyTank : HeavyVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "tv_medium_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.heavy,
			country = Country.ussr,

			power = 3,
			defense = 0,
			toughness = 9,
			increase = 2,
			cost = 3,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}