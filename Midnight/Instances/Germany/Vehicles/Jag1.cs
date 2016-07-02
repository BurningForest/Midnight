using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class Jag1 : SpatgVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<Jag1>() {
			ID = "gv_panzerjagerI",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Spatg,
			Country = Country.Germany,

			Power = 3,
			Defense = 0,
			Toughness = 3,
			Increase = 0,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}