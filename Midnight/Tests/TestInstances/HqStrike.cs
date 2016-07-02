using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class HqStrike : Hq
	{
		public static readonly Proto proto = new ParameterizedProto<HqStrike>() {
			ID = "th_strike",
			Level = 1,
			Type = Type.HQ,
			Subtype = Subtype.Strike,
			Country = Country.Germany,

			Power = 3,
			Toughness = 20,
			Increase = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}