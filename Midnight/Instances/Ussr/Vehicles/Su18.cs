using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Su18 : HeavyVehicle
	{
		public static readonly Proto Proto = new ParameterizedProto<Su18>() {
			ID = "sv_su18",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Spg,
			Country = Country.USSR,

			Power = 1,
			Defense = 0,
			Toughness = 4,
			Increase = 0,
			Cost = 2,
		};

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}