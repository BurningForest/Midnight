using System;
using Midnight.Cards;
using Midnight.Core;
using Midnight.Abilities;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
	internal abstract class Collector<TAbility, TOption>
		where TAbility : CardAbility
		where TOption : SpecificOptions
	{
		protected readonly Card card;

		internal Collector (Card card)
		{
			this.card = card;
		}

		internal TOption Collect ()
		{
			var ability = card.abilities.Get<TAbility>();

			if (ability != null && ability.Validate() == Status.Success) {
				return GetOptions(ability);
			} else {
				return null;
			}
		}

		protected abstract TOption GetOptions (TAbility ability);
	}
}