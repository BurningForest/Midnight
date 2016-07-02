using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonEnforceArtillery : Platoon.Enforce
	{
		public static readonly Proto proto = new Proto<PlatoonEnforceArtillery>() {
			id = "tp_enforce_artillery",
			level = 1,
			type = Type.Platoon,
			subtype = Subtype.Artillery,
			country = Country.USA,

			power = 1,
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