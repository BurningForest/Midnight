using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonEnforceScout : Platoon.Enforce
	{
		public static readonly Proto proto = new Proto<PlatoonEnforceScout>() {
			id = "tp_enforce_scout",
			level = 1,
			type = Type.Platoon,
			subtype = Subtype.Scout,
			country = Country.USSR,

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