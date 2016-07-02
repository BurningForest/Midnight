using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Ms1 : LightVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<Ms1>() {
			ID = "sv_ms1",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Light,
			Country = Country.USSR,

			Power = 1,
			Defense = 0,
			Toughness = 4,
			Increase = 1,
			Cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}