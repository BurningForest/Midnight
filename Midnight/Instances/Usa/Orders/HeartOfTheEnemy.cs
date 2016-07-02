using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Orders
{
	public class HeartOfTheEnemy : Order
	{
		// Нанесите 2 повреждения выбранному штабу, технике или взводу.

		public static readonly Proto proto = new ParameterizedProto<HeartOfTheEnemy>() {
			ID = "uo_crushprussian",
			Level = 1,
			Type = Type.Order,
			Country = Country.USA,
			
			Cost = 2,
		};

		public class HeartOfTheEnemyAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new[] { new DealDamage(2, card, target) };
			}

			protected override Search Targets (Search search)
			{
				return search
					.Enemy().Forefront()
					.Vehicle().Hq().Platoon();
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new HeartOfTheEnemyAbility());
		}
	}
}
