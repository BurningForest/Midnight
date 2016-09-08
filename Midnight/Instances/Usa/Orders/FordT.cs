using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.Instances.Usa.Orders
{
    public class FordT : Order
    {
        // Возьмите карту.
        // Восстановите 2 прочности своему штабу.

        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<FordT>("uo_ford_t");

        public class HelpForTheFrontAbility : SpecificAbility
        {
            protected override GameAction[] Actions(ForefrontCard target)
            {
                return new GameAction[] {
                    new DrawRandom(Chief),
                    new HealDamage(2, Card, Chief.Cards.GetHq())
                };
            }

            protected override Search Targets(Search search)
            {
                return null;
            }
        }

        public override Proto GetProto()
        {
            return Proto;
        }

        public override void InitAbilities()
        {
            base.InitAbilities();

            Abilities.Add(new HelpForTheFrontAbility());
        }
    }
}
