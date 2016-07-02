using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonProtectIntendancy : Platoon.Protect
	{
		public static readonly Proto proto = new Proto<PlatoonProtectIntendancy>() {
			id = "tp_protect_intendancy",
			level = 1,
			type = Type.Platoon,
			subtype = Subtype.Intendancy,
			country = Country.Germany,

			power = 0,
			defense = 3,
			toughness = 3,
			increase = 0,
			cost = 1,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}