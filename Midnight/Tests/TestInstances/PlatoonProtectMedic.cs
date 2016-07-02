using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class PlatoonProtectMedic : Platoon.Protect
	{
		public static readonly Proto proto = new ParameterizedProto<PlatoonProtectIntendancy>() {
			ID = "tp_protect_medic",
			Level = 1,
			Type = Type.Platoon,
			Subtype = Subtype.Medic,
			Country = Country.USA,

			Power = 0,
			Defense = 2,
			Toughness = 7,
			Increase = 0,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}