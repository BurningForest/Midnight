using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class A7v : HeavyVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<A7v>() {
			ID = "gv_a7v",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Heavy,
			Country = Country.Germany,

			Power = 2,
			Defense = 0,
			Toughness = 8,
			Increase = 1,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}