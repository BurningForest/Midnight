using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class T35_1 : HeavyVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<T35_1>() {
			ID = "sv_t351",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Heavy,
			Country = Country.USSR,

			Power = 3,
			Defense = 0,
			Toughness = 9,
			Increase = 1,
			Cost = 6,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}