using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class Liberty : HeavyVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<Liberty>() {
			ID = "uv_mark7liberty",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Heavy,
			Country = Country.USA,

            Power = 4,
			Defense = 0,
			Toughness = 7,
			Increase = 2,
			Cost = 7,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}