using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankMedium : MediumVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<TankMedium>() {
			ID = "tv_Medium_tank",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Medium,
			Country = Country.Germany,

			Power = 2,
			Defense = 0,
			Toughness = 5,
			Increase = 1,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}