using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankHeavy : HeavyVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<TankHeavy>() {
			ID = "tv_Medium_tank",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Heavy,
			Country = Country.USSR,

			Power = 3,
			Defense = 0,
			Toughness = 9,
			Increase = 2,
			Cost = 6,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}