using Midnight.Abilities;
using Midnight.Cards;
using Midnight.Core;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
    internal abstract class Collector<TAbility, TOption>
        where TAbility : CardAbility
        where TOption : SpecificOptions
    {
        protected readonly Card Card;

        internal Collector(Card card)
        {
            Card = card;
        }

        internal TOption Collect()
        {
            var ability = Card.Abilities.Get<TAbility>();

            if (ability != null && ability.Validate() == Status.Success)
            {
                return GetOptions(ability);
            }
            return null;
        }

        protected abstract TOption GetOptions(TAbility ability);
    }
}