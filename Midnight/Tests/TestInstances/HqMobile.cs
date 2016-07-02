using Midnight.Abilities.Aggression;
using Midnight.Abilities.Passive;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.TestInstances
{
	public class HqMobile : Hq
	{
		public static readonly Proto proto = new Proto<HqMobile>() {
			id = "th_mobile",
			level = 1,
			type = Type.HQ,
			subtype = Subtype.Strike,
			country = Country.USA,

			power = 3,
			toughness = 14,
			increase = 8,
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