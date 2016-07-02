using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class T21 : MediumVehicle
	{
		public static readonly Proto proto = new Proto<T21>() {
			id = "gv_t21",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Medium,
			country = Country.Germany,

			power = 3,
			defense = 0,
			toughness = 5,
			increase = 1,
			cost = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}