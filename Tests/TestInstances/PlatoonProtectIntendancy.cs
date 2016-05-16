using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonProtectIntendancy : Platoon.Protect
	{
		public static readonly Proto proto = new Proto() {
			id = "tp_protect_intendancy",
			level = 1,
			type = Type.platoon,
			subtype = Subtype.intendancy,
			country = Country.germany,

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