using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.Instances.Ussr.Orders
{
    public class IlyaMuromets : Order
	{
        // Нанесите 2 повреждения выбранному штабу, технике или взводу.

        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<IlyaMuromets>("so_ilya_muromets");

		public class HeartOfTheEnemyAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new GameAction[] { new DealDamage(2, Card, target) };
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
			return Proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			Abilities.Add(new HeartOfTheEnemyAbility());
		}
	}
}
