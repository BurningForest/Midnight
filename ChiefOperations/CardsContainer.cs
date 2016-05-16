using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Midnight.ChiefOperations
{
	public class CardsContainer
	{
		private readonly List<Card> cards = new List<Card>();
		public readonly CardFactory factory;
		private Chief chief;
		private bool isShuffle = true;

		private Random random = new Random();

		public CardsContainer (Chief chief)
		{
			this.chief = chief;
			factory = new CardFactory(chief);
		}

		public List<Card> GetAll ()
		{
			return cards;
		}

		public CardsContainer Add (Card card)
		{
			cards.Add(card);
			card.SetChief(chief);
			return this;
		}

		public void SetShuffleOn ()
		{
			isShuffle = true;
		}

		public void SetShuffleOff ()
		{
			isShuffle = false;
		}

		public bool IsShuffleOn ()
		{
			return isShuffle;
		}

		public List<Card> FromLocation (Location location)
		{
			return cards.Where(card => card.GetLocation().Is(location)).ToList();
		}

		public Card GetRandomDeckCard ()
		{
			var deck = FromLocation(Location.deck);

			if (deck.Count == 0) {
				return null;
			}

			return IsShuffleOn()
				? deck[random.Next(0, deck.Count)]
				: deck[0];
		}

		public List<Card> GetShuffledDeck ()
		{
			var deck = FromLocation(Location.deck);

			if (IsShuffleOn()) {
				Shuffle(deck);
			}

			return deck;
		}

		public Platoon GetPlatoonBySubtype (Subtype subtype)
		{
			foreach (var card in cards) {
				if (card.IsActive<Platoon>() && card.Is(subtype)) {
					return (Platoon)card;
				}
			}

			return null;
		}

		public List<Platoon> GetOrderedPlatoons ()
		{
			var platoons = new List<Platoon>();

			foreach (var subtype in Platoon.subtypeOrder) {
				var item = GetPlatoonBySubtype(subtype);

				if (item != null) {
					platoons.Add(item);
				}
			}

			return platoons;
		}

		public List<Hq> GetAliveHqs ()
		{
			return cards
				.Where(card => card.IsActive<Hq>())
				.Cast<Hq>()
				.ToList();
		}

		public Hq GetHq ()
		{
			foreach (var card in cards) {
				if (card.IsActive<Hq>()) {
					return (Hq)card;
				}
			}

			return null;
		}

		public bool HasHq (Country country)
		{
			return GetAliveHqs().Any(hq => hq.Is(country));
		}

		public bool HasHq (Subtype subtype)
		{
			return GetAliveHqs().Any(hq => hq.Is(subtype));
		}

		public bool HasHq (Country country, Subtype subtype)
		{
			return GetAliveHqs().Any(hq => hq.Is(country) && hq.Is(subtype));
		}

		private void Shuffle<T> (List<T> list)
		{
			for (int i = 0; i < list.Count; i++) {
				int r = random.Next(i, list.Count);

				// Swap cards
				var temp = list[i];
				list[i] = list[r];
				list[r] = temp;
			}
		}
	}
}
