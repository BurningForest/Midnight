using Midnight.ActionManager;
using Midnight.Cards.Types;
using System.Collections.Generic;
using System;
using Midnight.Actions;

namespace Midnight.Core
{
	public class Lantern
	{
		private List<int> cards = new List<int>();
		private readonly Engine engine;

		public Lantern (Engine engine)
		{
			this.engine = engine;
		}

		public void RecountTo (GameAction action)
		{
			foreach (FieldCard card in engine.field.GetAllCards()) {
				var change = GetChange(card);
				if (change != null) {
					action.AddChild(change);
				}
			}
		}

		private GameAction GetChange (FieldCard card)
		{
			return card.IsSpotted()
				? Spotted(card)
				: Unspotted(card);
		}

		private GameAction Spotted (FieldCard card)
		{
			if (!cards.Contains(card.Id)) {
				cards.Add(card.Id);
				return new Spotted(card);
			}

			return null;
		}

		private GameAction Unspotted (FieldCard card)
		{
			if (cards.Contains(card.Id)) {
				cards.Remove(card.Id);
				return new Unspotted(card);
			}

			return null;
		}

		public void CloneFrom (Lantern source)
		{
			cards.AddRange(source.cards);
		}
	}
}
