using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T7Combat : LightVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<T7Combat>() {
			ID = "uv_t7combatcar",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Light,
			Country = Country.USA,

			Power = 3,
			Defense = 0,
			Toughness = 1,
			Increase = 0,
			Cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}