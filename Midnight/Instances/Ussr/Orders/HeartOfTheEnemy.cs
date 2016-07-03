using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.Instances.Ussr.Orders
{
    public class HeartOfTheEnemy : Order
	{
        // Нанесите 2 повреждения выбранному штабу, технике или взводу.

        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<HeartOfTheEnemy>("so_ilya_muromets");

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
