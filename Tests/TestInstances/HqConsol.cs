using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Tests.TestInstances
{
	public class HqConsol : Hq
	{
		public static readonly Proto proto = new Proto() {
			id = "th_consolidated",
			level = 1,
			type = Type.hq,
			subtype = Subtype.consolidated,
			country = Country.ussr,

			power = 2,
			toughness = 25,
			increase = 7,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}