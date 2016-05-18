using System;
using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Abilities.Activating;
using Midnight.Abilities.Aggression;
using Midnight.Abilities.Positioning;
using Midnight.Core;
using Midnight.Abilities;

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

				if (option != null) {
					result.Add(option);
				}
			}

			return result;
		}

		private CardOption GetOption (Card card)
		{
			var option = new CardOption();
			option.cardId = card.id;

			option.deploys = GetDeploys(card);
			option.moves   = GetMoves  (card);
			option.attacks = GetAttacks(card);
			option.orders  = GetOrders (card);

			return option;
		}

		private bool IsValidAbility<TCard> (CardActiveAbility<TCard> ability)
			where TCard : Card
		{
			return ability != null && ability.Validate() == Status.Success;
		}

		private List<ISingleOption> GetOrders (Card card)
		{
			var ability = card.abilities.Get<Ordering>();

			if (!IsValidAbility(ability)) {
				return null;
			}

			var list = new List<ISingleOption>();
			return list;

		}

		private List<ISingleOption> GetAttacks (Card card)
		{
			var ability = card.abilities.Get<Ordering>();

			if (!IsValidAbility(ability)) {
				return null;
			}

			var list = new List<ISingleOption>();
			return list;
		}

		private List<ISingleOption> GetMoves (Card card)
		{
			var ability = card.abilities.Get<Ordering>();

			if (!IsValidAbility(ability)) {
				return null;
			}

			var list = new List<ISingleOption>();
			return list;
		}

		private List<ISingleOption> GetDeploys (Card card)
		{
			var ability = card.abilities.Get<Ordering>();

			if (!IsValidAbility(ability)) {
				return null;
			}

			var list = new List<ISingleOption>();
			return list;
		}
	}
}
