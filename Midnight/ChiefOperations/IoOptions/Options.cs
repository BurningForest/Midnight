using System.Collections.Generic;
using System.Linq;
using Midnight.Cards;
using Midnight.ChiefOperations.IoOptions.Collectors;

namespace Midnight.ChiefOperations.IoOptions
{
	public class Options
	{
		private readonly Chief _chief;

		public Options (Chief chief)
		{
			_chief = chief;
		}

		public List<CardOption> GetAvailable ()
		{
		    return _chief.cards
                .GetAll().Select(GetOption)
                .Where(option => !option.IsEmpty())
                .ToList();
		}

	    private static CardOption GetOption (Card card)
		{
		    var option = new CardOption
		    {
		        CardId = card.id
		    };

		    if (card.GetLocation().IsReserve())
		    {
                option.Deploys = new DeploysCollector(card).Collect();
                option.Orders = new OrdersCollector(card).Collect();
            }

		    if (card.GetLocation().IsBattlefield())
		    {
                option.Moves = new MovesCollector(card).Collect();
                option.Attacks = new AttacksCollector(card).Collect();
            }
		    return option;
		}
	}
}
