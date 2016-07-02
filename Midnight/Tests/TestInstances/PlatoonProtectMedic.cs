using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonProtectMedic : Platoon.Protect
	{
		public static readonly Proto proto = new Proto<PlatoonProtectIntendancy>() {
			id = "tp_protect_medic",
			level = 1,
			type = Type.Platoon,
			subtype = Subtype.Medic,
			country = Country.USA,

			power = 0,
			defense = 2,
			toughness = 7,
			increase = 0,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}