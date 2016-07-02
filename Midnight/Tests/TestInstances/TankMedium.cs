using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class TankMedium : MediumVehicle
	{
		public static readonly Proto proto = new Proto<TankMedium>() {
			id = "tv_Medium_tank",
			level = 1,
			type = Type.Vehicle,
			subtype = Subtype.Medium,
			country = Country.Germany,

			power = 2,
			defense = 0,
			toughness = 5,
			increase = 1,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}