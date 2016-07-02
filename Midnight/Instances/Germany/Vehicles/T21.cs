using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class T21 : MediumVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<T21>() {
			ID = "gv_t21",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Medium,
			Country = Country.Germany,

			Power = 3,
			Defense = 0,
			Toughness = 5,
			Increase = 1,
			Cost = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}