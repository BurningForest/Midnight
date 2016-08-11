using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Abilities.Aggression;
using Midnight.Core;
using Midnight.Cards.Types;
using System;
using System.Linq;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
	internal class AttacksCollector : Collector<Aggression, AttackOptions>
	{
		public AttacksCollector (Card card) : base(card) { }

		protected override AttackOptions GetOptions (Aggression ability)
		{
			var attacks = new List<TargetOption>();

			foreach (var target in GetAllowedTargets()) {
				attacks.Add(new TargetOption() { targetId = target.id });
			}

			if (attacks.Count == 0) {
				return null;
			} else {
				return new AttackOptions() { targets = attacks.ToArray() };
			}
		}

		private List<FieldCard> GetAllowedTargets ()
		{
			var weapon = card.abilities.Get<Weapon>();

		    return card.GetChief().GetOpponent().cards.GetAll().OfType<FieldCard>().Where(fieldCard => weapon.Validate(fieldCard) == Status.Success).ToList();
		}
	}
}
