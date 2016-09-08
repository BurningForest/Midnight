using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class HqConsol : Hq
	{
		public static readonly Proto proto = new ParameterizedProto<HqConsol>() {
			ID = "th_consolidated",
			Level = 1,
			Type = Type.HQ,
			Subtype = Subtype.Consolidated,
			Country = Country.USSR,

			Power = 2,
			Toughness = 25,
			Increase = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}