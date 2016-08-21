using System;
using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Abilities.Activating;
using System.Linq;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
    internal class OrdersCollector : Collector<Ordering, OrderOptions>
    {
        public OrdersCollector(Card card) : base(card) { }

        //todo: What types of Properties are in the orders? Now only damage prediction
        protected override OrderOptions GetOptions(Ordering ability)
        {
            var option = new OrderOptions();
            var targets = ability.GetPotentialTargets();

            if (targets == null)
            {
                var emulated = Card.GetChief().GetEmulated();
                emulated.Order(new Io.SingleCard
                {
                    CardId = Card.Id
                });
                option.Predictions = emulated.GetDamagePredictions();
                return option;
            }

            var list = new List<TargetOption>();
            foreach (var target in targets)
            {
                var emulated = Card.GetChief().GetEmulated();
                emulated.Order(new Io.Target
                {
                    SourceId = Card.Id,
                    TargetId = target.Id
                });
                list.Add(new TargetOption { TargetId = target.Id, Predictions = emulated.GetDamagePredictions()});
            }
            option.Type = TargetType.Card;
            option.Targets = list.ToArray();
            return option;
        }
    }
}