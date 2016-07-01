using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Germany.Vehicle
{
	public class T21 : MediumVehicle
	{
		public static readonly Proto proto = new Proto<T21>() {
			id = "gv_t21",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.medium,
			country = Country.germany,

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