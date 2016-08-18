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

            if (source.Turn.GetOwner() != null)
            {
                _engine.Turn.StartWith(
                    _engine.Chiefs[source.Turn.GetOwner().Index],
                    source.Turn.GetNumber()
                );
            }
            _engine.Triggers.CloneFrom(source.Triggers);
            _engine.Lantern.CloneFrom(source.Lantern);

            PreCloneChief(source.Chiefs[0], _engine.Chiefs[0]);
            PreCloneChief(source.Chiefs[1], _engine.Chiefs[1]);
            PostCloneCardsList(source.Chiefs[0].Cards.GetAll());
            PostCloneCardsList(source.Chiefs[1].Cards.GetAll());
        }

        internal Engine.ClonedEngine GetClone()
        {
            return _engine;
        }

        private void PostCloneCardsList(List<Card> list)
        {
            foreach (var source in list)
            {
                PostCloneCard(_engine.Cache.Get(source.Id), source);
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

            _engine.Cache.ManualRegister(clone, card.Id);
            chief.Cards.Add(clone);
        }
    }
}
