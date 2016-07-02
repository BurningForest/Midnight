using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class HqStrike : Hq
	{
		public static readonly Proto proto = new Proto<HqStrike>() {
			id = "th_strike",
			level = 1,
			type = Type.HQ,
			subtype = Subtype.Strike,
			country = Country.Germany,

			power = 3,
			toughness = 20,
			increase = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}