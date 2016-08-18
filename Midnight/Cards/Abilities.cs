using System.Collections.Generic;
using System.Linq;
using Midnight.Abilities;

namespace Midnight.Cards
{
	public class Abilities
	{
		private readonly List<CardAbility> _active = new List<CardAbility>();
		private readonly Card _card;

		public Abilities (Card card)
		{
			_card = card;
		}

		public Abilities (Card card, CardAbility[] abilities)
		{
			_card = card;

			Add(abilities);
		}

		public void Add (CardAbility ability)
		{
			ability.SetOwner(_card);
			_active.Add(ability);
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
		    return _active.Where(ability => ability is TAbility && ability.IsActive()).Cast<TAbility>().FirstOrDefault();
		}

	    public bool Has<TAbility> ()
			where TAbility : CardAbility
		{
			return Get<TAbility>() != null;
		}

		public void CloneFrom (Abilities source)
		{
			foreach (var ability in source._active)
            {
				Add(ability.CloneFor(_card));
			}
		}
	}
}
