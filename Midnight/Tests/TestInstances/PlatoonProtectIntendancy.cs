using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonProtectIntendancy : Platoon.Protect
	{
		public static readonly Proto proto = new ParameterizedProto<PlatoonProtectIntendancy>() {
			ID = "tp_protect_intendancy",
			Level = 1,
			Type = Type.Platoon,
			Subtype = Subtype.Intendancy,
			Country = Country.Germany,

			Power = 0,
			Defense = 3,
			Toughness = 3,
			Increase = 0,
			Cost = 1,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}