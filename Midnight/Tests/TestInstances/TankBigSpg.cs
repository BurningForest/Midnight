using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankBigSpg : SpgVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<TankBigSpg>() {
			ID = "tv_big_Spg_tank",
			Level = 5,
			Type = Type.Vehicle,
			Subtype = Subtype.Spg,
			Country = Country.Germany,

			Power = 8,
			Defense = 0,
			Toughness = 4,
			Increase = 0,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}