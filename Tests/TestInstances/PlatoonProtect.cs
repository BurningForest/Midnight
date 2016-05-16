using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonProtect : Platoon.Protect
	{
		public static readonly Proto proto = new Proto() {
			id = "tp_defense",
			level = 1,
			type = Type.platoon,
			subtype = Subtype.communications,
			country = Country.germany,

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