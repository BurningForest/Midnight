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
	public class HelpForTheFront : Order
	{
        // Возьмите карту.
        // Восстановите 2 прочности своему штабу.

        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<HelpForTheFront>("uo_ford_t");

		public class HelpForTheFrontAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new GameAction[] {
					new DrawRandom(chief),
					new HealDamage(2, card, chief.cards.GetHq())
				};
			}

			protected override Search Targets (Search search)
			{
				return null;
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new HelpForTheFrontAbility());
		}
	}
}
