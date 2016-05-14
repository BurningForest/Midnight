using Midnight.Engine.Cards;
using Midnight.Engine.Cards.Prototype;

namespace Midnight.Engine.Instances.Usa.Vehicle.Light
{
	public class T1Lt : Cards.Vehicles.LightVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "uv_t1lt",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.light,
			country = Country.usa,

			power = 2,
			defense = 0,
			toughness = 3,
			increase = 1,
			cost = 3,
		};

		public override Proto GetProto()
		{
			return proto;
		}
	}
}