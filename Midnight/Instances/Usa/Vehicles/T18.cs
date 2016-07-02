using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T18 : SpatgVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<T18>() {
			ID = "uv_t18",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Spatg,
			Country = Country.USA,

			Power = 2,
			Defense = 0,
			Toughness = 5,
			Increase = 0,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}