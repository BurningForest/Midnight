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

		public CardsContainer AddCards (Card[] cards)
		{
			foreach (var card in cards) {
				Add(card);
			}
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
			return cards.First(card => card is Platoon && card.IsActive() && card.Is(subtype)) as Platoon;
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
				.Where(card => card is Hq && card.IsActive())
				.Cast<Hq>()
				.ToList();
		}

		public Hq GetHq ()
		{
			Card hq = cards.First(card => card is Hq && card.IsActive());

			return hq == null ? null : (Hq)hq;
		}

		public bool HasHq (Country country)
		{
			return null != GetAliveHqs().First(hq => hq.Is(country));
		}

		public bool HasHq (Subtype subtype)
		{
			return null != GetAliveHqs().First(hq => hq.Is(subtype));
		}

		public bool HasHq (Country country, Subtype subtype)
		{
			return null != GetAliveHqs().First(hq => hq.Is(country) && hq.Is(subtype));
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
