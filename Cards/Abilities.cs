using Midnight.Abilities;
using System.Collections.Generic;

namespace Midnight.Cards
{
	public class Abilities
	{
		private readonly List<CardAbility> active = new List<CardAbility>();
		private readonly Card card;

		public Abilities (Card card)
		{
			this.card = card;
		}

		public Abilities (Card card, CardAbility[] abilities)
		{
			this.card = card;

			Add(abilities);
		}

		public void Add (CardAbility ability)
		{
			ability.SetOwner(card);
			active.Add(ability);
		}

		public void Add (params CardAbility[] abilities)
		{
			foreach (var ability in abilities) {
				Add(ability);
			}
		}

		public TAbility Get<TAbility> ()
			where TAbility : CardAbility
		{
			foreach (var ability in active) {
				if (ability is TAbility) {
					return (TAbility)ability;
				}
			}

			return null;
		}

		public bool Has<TAbility> ()
			where TAbility : CardAbility
		{
			return Get<TAbility>() != null;
		}

		public void CloneFrom (Abilities source)
		{
			foreach (var ability in source.active) {
				Add(ability.CloneFor(card));
			}
		}
	}
}
