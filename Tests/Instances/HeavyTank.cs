using Midnight.Engine.Cards;
using Midnight.Engine.Cards.Prototype;
using Midnight.Engine.Cards.Vehicles;

namespace Midnight.Tests.Instances
{
	public class HeavyTank : Heavy
	{
		public static readonly Proto proto = new Proto() {
			id = "tv_medium_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.heavy,
			country = Country.ussr,

			power = 3,
			defense = 0,
			toughness = 8,
			increase = 2,
			cost = 3,
		};

		public override Proto GetProto()
		{
			return proto;
		}
	}
}