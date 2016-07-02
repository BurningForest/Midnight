using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T6 : MediumVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<T6>() {
			ID = "uv_t6",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Medium,
			Country = Country.USA,

			Power = 2,
			Defense = 0,
			Toughness = 7,
			Increase = 1,
			Cost = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}