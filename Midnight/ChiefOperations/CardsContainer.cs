using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Midnight.ChiefOperations
{
    public class CardsContainer
    {
        private readonly List<Card> _cards = new List<Card>();
        public CardFactory Factory { get; }
        private readonly Chief _chief;
        private bool _isShuffle = true;

        private static readonly Random Random = new Random();

        public CardsContainer(Chief chief)
        {
            this._chief = chief;
            Factory = new CardFactory(chief);
        }

        public List<Card> GetAll()
        {
            return _cards;
        }

        public CardsContainer Add(Card card)
        {
            _cards.Add(card);
            card.SetChief(_chief);
            return this;
        }

        public void SetShuffleOn()
        {
            _isShuffle = true;
        }

        public void SetShuffleOff()
        {
            _isShuffle = false;
        }

        public bool IsShuffleOn()
        {
            return _isShuffle;
        }

        public int CountLocation(Location location)
        {
            return _cards.Count(card => card.GetLocation().Is(location));
        }

        public List<Card> FromLocation(Location location)
        {
            return _cards.Where(card => card.GetLocation().Is(location)).ToList();
        }

        public List<Card> FromLocationShuffled(Location location)
        {
            var cards = FromLocation(location);

            if (IsShuffleOn())
            {
                Shuffle(cards);
            }

            return cards;
        }

        public Card GetRandomDeckCard()
        {
            var deck = FromLocation(Location.Deck);

            if (deck.Count == 0)
            {
                return null;
            }

            return IsShuffleOn()
                ? deck[Random.Next(0, deck.Count)]
                : deck[0];
        }

        public List<Card> GetShuffledDeck()
        {
            return FromLocationShuffled(Location.Deck);
        }

        public Platoon GetPlatoonBySubtype(Subtype subtype)
        {
            return _cards.Where(card => card.IsActive<Platoon>() && card.Is(subtype)).Cast<Platoon>().FirstOrDefault();
        }

        public List<Platoon> GetOrderedPlatoons()
        {
            return Platoon.SubtypeOrder.Select(GetPlatoonBySubtype).Where(item => item != null).ToList();
        }

        public List<Hq> GetAliveHqs()
        {
            return _cards
                .Where(card => card.IsActive<Hq>())
                .Cast<Hq>()
                .ToList();
        }

        public Hq GetHq()
        {
            return _cards.Where(card => card.IsActive<Hq>()).Cast<Hq>().FirstOrDefault();
        }

        public bool HasHq(Country country)
        {
            return GetAliveHqs().Any(HQ => HQ.Is(country));
        }

        public bool HasHq(Subtype subtype)
        {
            return GetAliveHqs().Any(hq => hq.Is(subtype));
        }

        public bool HasHq(Country country, Subtype subtype)
        {
            return GetAliveHqs().Any(hq => hq.Is(country) && hq.Is(subtype));
        }

        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int r = Random.Next(i, list.Count);

                // Swap cards
                var temp = list[i];
                list[i] = list[r];
                list[r] = temp;
            }
        }
    }
}
