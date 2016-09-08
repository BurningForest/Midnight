using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonEnforceArtillery : Platoon.Enforce
	{
		public static readonly Proto proto = new ParameterizedProto<PlatoonEnforceArtillery>() {
			ID = "tp_enforce_artillery",
			Level = 1,
			Type = Type.Platoon,
			Subtype = Subtype.Artillery,
			Country = Country.USA,

			Power = 1,
			Defense = 0,
			Toughness = 5,
			Increase = 1,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}