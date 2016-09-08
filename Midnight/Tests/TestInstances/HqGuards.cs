using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class HqGuards : Hq
	{
		public static readonly Proto proto = new ParameterizedProto<HqGuards>() {
			ID = "th_guards",
			Level = 1,
			Type = Type.HQ,
			Subtype = Subtype.Guards,
			Country = Country.USA,

			Power = 1,
			Toughness = 15,
			Increase = 9,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}