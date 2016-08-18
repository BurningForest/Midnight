using Midnight.Cards;
using System.Collections.Generic;
using System;

namespace Midnight.Core
{
    public class Cache
    {
        readonly Dictionary<int, Card> _container = new Dictionary<int, Card>();

        int _previous;

        internal int Register(Card card)
        {
            return ManualRegister(card, _previous + 1);
        }

        internal int ManualRegister(Card card, int id)
        {
            if (_container.ContainsKey(id))
            {
                throw new ArgumentException("Id `" + id + "` is busy");
            }

            if (id > _previous)
            {
                _previous = id;
            }

            _container.Add(id, card);

            return id;
        }

        public Card Get(int id)
        {
            return _container.ContainsKey(id)
                ? _container[id]
                : null;
        }
    }
}
