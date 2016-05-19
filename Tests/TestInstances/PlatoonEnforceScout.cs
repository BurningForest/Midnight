using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonEnforceScout : Platoon.Enforce
	{
		public static readonly Proto proto = new Proto<PlatoonEnforceScout>() {
			id = "tp_enforce_scout",
			level = 1,
			type = Type.platoon,
			subtype = Subtype.scout,
			country = Country.ussr,

			power = 2,
			defense = 0,
			toughness = 4,
			increase = 0,
			cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}