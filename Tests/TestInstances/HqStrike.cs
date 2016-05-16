using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Tests.TestInstances
{
	public class HqStrike : Hq
	{
		public static readonly Proto proto = new Proto() {
			id = "th_strike",
			level = 1,
			type = Type.hq,
			subtype = Subtype.strike,
			country = Country.germany,

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