using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankSpatg : SpatgVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<TankSpatg>() {
			ID = "tv_Spatg_tank",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Spatg,
			Country = Country.Germany,

			Power = 2,
			Defense = 0,
			Toughness = 2,
			Increase = 0,
			Cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}