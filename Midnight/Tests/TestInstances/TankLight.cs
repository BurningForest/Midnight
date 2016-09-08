using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankLight : LightVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<TankLight>() {
			ID = "tv_Light_tank",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Light,
			Country = Country.USA,

			Power = 1,
			Defense = 0,
			Toughness = 2,
			Increase = 1,
			Cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}