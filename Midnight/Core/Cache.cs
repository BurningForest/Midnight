using Midnight.Cards;
using System.Collections.Generic;
using System;

namespace Midnight.Core
{
	public class Cache
	{
		Dictionary<int, Card> container = new Dictionary<int, Card>();

		int previous = 0;

		internal int Register (Card card)
		{
			return ManualRegister(card, previous + 1);
		}

		internal int ManualRegister (Card card, int id)
		{
			if (container.ContainsKey(id)) {
				throw new ArgumentException("Id `" + id + "` is busy");
			}

			if (id > previous) {
				previous = id;
			}

			container.Add(id, card);

			return id;
		}

		public Card Get (int id)
		{
			return container.ContainsKey(id)
				? container[id]
				: null;
		}
	}
}
