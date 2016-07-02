using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class T24 : HeavyVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<T24>() {
			ID = "sv_t24",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Medium,
			Country = Country.USSR,

			Power = 1,
			Defense = 0,
			Toughness = 9,
			Increase = 1,
			Cost = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}