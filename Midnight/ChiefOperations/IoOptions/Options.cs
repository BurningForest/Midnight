using System.Collections.Generic;
using Midnight.Cards;
using Midnight.ChiefOperations.IoOptions.Collectors;

namespace Midnight.ChiefOperations.IoOptions
{
	public class Options
	{
		private Chief chief;

		public Options (Chief chief)
		{
			this.chief = chief;
		}

		public List<CardOption> GetAvailable ()
		{
			var result = new List<CardOption>();

			foreach (var card in chief.cards.GetAll()) {
				CardOption option = GetOption(card);

				if (!option.IsEmpty()) {
					result.Add(option);
				}
			}

			return result;
		}

		private CardOption GetOption (Card card)
		{
			var option = new CardOption();

			option.cardId  = card.id;

			option.deploys = new DeploysCollector (card).Collect();
			option.moves   = new MovesCollector   (card).Collect();
			option.attacks = new AttacksCollector (card).Collect();
			option.orders  = new OrdersCollector  (card).Collect();

			return option;
		}
	}
}
