using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankSpg : SpgVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<TankSpg>() {
			ID = "tv_Spg_tank",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Spg,
			Country = Country.USA,

			Power = 1,
			Defense = 0,
			Toughness = 3,
			Increase = 0,
			Cost = 0,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}