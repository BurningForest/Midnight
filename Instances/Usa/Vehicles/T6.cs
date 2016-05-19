using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T6 : MediumVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "uv_t6",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.medium,
			country = Country.usa,

			power = 2,
			defense = 0,
			toughness = 7,
			increase = 1,
			cost = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}