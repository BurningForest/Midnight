using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.Instances.Germany.Orders
{
	public class ParisGun : Order
	{
        // Нанесите 2 повреждения выбранной технике.
        // Восстановите 2 прочности вашему штабу.

        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<ParisGun>("go_paris_gun");

		public class EachBattleAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new GameAction[] {
					new DealDamage(2, Card, target),
					new HealDamage(2, Card, Chief.cards.GetHq())
				};
			}

			protected override Search Targets (Search search)
			{
				return search
					.Enemy().Forefront()
					.Vehicle();
			}
		}

		public override Proto GetProto ()
		{
			return Proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new EachBattleAbility());
		}
	}
}
