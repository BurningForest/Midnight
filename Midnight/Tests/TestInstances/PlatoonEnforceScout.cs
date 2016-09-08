using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonEnforceScout : Platoon.Enforce
	{
		public static readonly Proto proto = new ParameterizedProto<PlatoonEnforceScout>() {
			ID = "tp_enforce_scout",
			Level = 1,
			Type = Type.Platoon,
			Subtype = Subtype.Scout,
			Country = Country.USSR,

			Power = 2,
			Defense = 0,
			Toughness = 4,
			Increase = 0,
			Cost = 2,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}