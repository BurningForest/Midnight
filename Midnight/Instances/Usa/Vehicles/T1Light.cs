using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T1Light : LightVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<T1Light>() {
			ID = "uv_t1lt",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Light,
			Country = Country.USA,

			Power = 2,
			Defense = 0,
			Toughness = 3,
			Increase = 1,
			Cost = 3,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}