using Midnight.Engine.Cards;
using Midnight.Engine.Cards.Prototype;
using Midnight.Engine.Cards.Vehicles;

namespace Midnight.Tests.Instances
{
	public class LightTank : LightVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "tv_light_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.light,
			country = Country.usa,

			power = 1,
			defense = 0,
			toughness = 2,
			increase = 1,
			cost = 1,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}