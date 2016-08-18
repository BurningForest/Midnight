using System.Collections.Generic;
using Midnight.ChiefOperations;
using Midnight.Cards;

namespace Midnight.Core
{
    public class Copier
    {
        private readonly Engine.ClonedEngine _engine;

        internal Copier(Engine source)
        {
            _engine = new Engine.ClonedEngine();

            if (source.turn.GetOwner() != null)
            {
                _engine.turn.StartWith(
                    _engine.chiefs[source.turn.GetOwner().Index],
                    source.turn.GetNumber()
                );
            }
            _engine.triggers.CloneFrom(source.triggers);
            _engine.lantern.CloneFrom(source.lantern);

            PreCloneChief(source.chiefs[0], _engine.chiefs[0]);
            PreCloneChief(source.chiefs[1], _engine.chiefs[1]);
            PostCloneCardsList(source.chiefs[0].Cards.GetAll());
            PostCloneCardsList(source.chiefs[1].Cards.GetAll());
        }

        internal Engine.ClonedEngine GetClone()
        {
            return _engine;
        }

        private void PostCloneCardsList(List<Card> list)
        {
            foreach (var source in list)
            {
                PostCloneCard(_engine.cache.Get(source.Id), source);
            }
        }

        private void PostCloneCard(Card target, Card source)
        {
            target.Abilities.CloneFrom(source.Abilities);
            target.Modifiers.CloneFrom(source.Modifiers, _engine);
        }

        private void PreCloneChief(Chief source, Chief target)
        {
            target.SetResources(source.GetResources());

            foreach (var card in source.Cards.GetAll())
            {
                PreCloneCard(card, target);
            }
        }

        private void PreCloneCard(Card card, Chief chief)
        {
            var clone = card.CloneFor(chief);

            _engine.cache.ManualRegister(clone, card.Id);
            chief.Cards.Add(clone);
        }
    }
}
