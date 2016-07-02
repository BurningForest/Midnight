using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class LTraktor : LightVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<LTraktor>() {
			ID = "gv_leichttraktor",
			Level = 1,
			Type = Type.Vehicle,
			Subtype = Subtype.Light,
			Country = Country.Germany,

			Power = 2,
			Defense = 0,
			Toughness = 2,
			Increase = 0,
			Cost = 1,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}