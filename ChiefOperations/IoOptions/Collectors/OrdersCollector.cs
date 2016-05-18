using System;
using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Abilities.Positioning;
using Midnight.Core;
using Midnight.Battlefield;
using Midnight.Abilities.Activating;
using System.Linq;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
	internal class OrdersCollector : Collector<Ordering, OrderOptions>
	{
		public OrdersCollector (Card card) : base(card) { }

		protected override OrderOptions GetOptions (Ordering ability)
		{
			var option = new OrderOptions();
			var targets = ability.GetPotentialTargets();

			if (targets != null) {
				option.type = TargetType.Card;
				option.targets = targets
					.Select(t => new TargetOption() { targetId = t.id })
					.ToArray();
			}

			return option;
		}
	}
}