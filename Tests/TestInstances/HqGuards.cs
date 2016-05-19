using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Tests.TestInstances
{
	public class HqGuards : Hq
	{
		public static readonly Proto proto = new Proto<HqGuards>() {
			id = "th_guards",
			level = 1,
			type = Type.hq,
			subtype = Subtype.guards,
			country = Country.usa,

			power = 1,
			toughness = 15,
			increase = 9,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}