using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonEnforceArtillery : Platoon.Enforce
	{
		public static readonly Proto proto = new Proto<PlatoonEnforceArtillery>() {
			id = "tp_enforce_artillery",
			level = 1,
			type = Type.platoon,
			subtype = Subtype.artillery,
			country = Country.usa,

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