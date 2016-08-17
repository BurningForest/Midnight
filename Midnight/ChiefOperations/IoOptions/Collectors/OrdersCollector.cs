using Midnight.Cards;
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

		    if (targets == null) return option;
		    option.Type = TargetType.Card;
		    option.Targets = targets
		        .Select(t => new TargetOption { TargetId = t.id })
		        .ToArray();

		    return option;
		}
	}
}