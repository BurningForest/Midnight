using System.Collections.Generic;
using System.Linq;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards.Types;

namespace Midnight.Core
{
    public class Lantern
    {
        private readonly List<int> _cards = new List<int>();
        private readonly Engine _engine;

        public Lantern(Engine engine)
        {
            _engine = engine;
        }

        public void RecountTo(GameAction action)
        {
            foreach (var change in _engine.field.GetAllCards().Select(GetChange).Where(change => change != null))
            {
                action.AddChild(change);
            }
        }

        private GameAction GetChange(FieldCard card)
        {
            return card.IsSpotted()
                ? Spotted(card)
                : Unspotted(card);
        }

        private GameAction Spotted(FieldCard card)
        {
            if (!_cards.Contains(card.Id))
            {
                _cards.Add(card.Id);
                return new Spotted(card);
            }

            return null;
        }

        private GameAction Unspotted(FieldCard card)
        {
            if (_cards.Contains(card.Id))
            {
                _cards.Remove(card.Id);
                return new Unspotted(card);
            }

            return null;
        }

        public void CloneFrom(Lantern source)
        {
            _cards.AddRange(source._cards);
        }
    }
}
