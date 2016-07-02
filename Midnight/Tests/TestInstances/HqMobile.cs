using Midnight.Abilities.Aggression;
using Midnight.Abilities.Passive;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class HqMobile : Hq
	{
		public static readonly Proto proto = new ParameterizedProto<HqMobile>() {
			ID = "th_mobile",
			Level = 1,
			Type = Type.HQ,
			Subtype = Subtype.Strike,
			Country = Country.USA,

			Power = 3,
			Toughness = 14,
			Increase = 8,
		};

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			abilities.Add(
				new MovementSlow(),
				new WeaponCannon(),
				new Attack(),
				new CounterAttack.Joined(),
				new PlatoonEnforced(),
				new PlatoonProtected()
			);
		}
	}
}