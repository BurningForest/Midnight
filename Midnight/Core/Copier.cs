using System.Collections.Generic;
using Midnight.ChiefOperations;
using Midnight.Cards;

namespace Midnight.Core
{
	public class Copier
	{
		private Engine.ClonedEngine engine;

		internal Copier (Engine source)
		{
			engine = new Engine.ClonedEngine();

			if (source.turn.GetOwner() != null) {
				engine.turn.StartWith(
					engine.chiefs[source.turn.GetOwner().Index],
					source.turn.GetNumber()
				);
			}
			engine.triggers.CloneFrom(source.triggers);
			engine.lantern.CloneFrom(source.lantern);

			PreCloneChief(source.chiefs[0], engine.chiefs[0]);
			PreCloneChief(source.chiefs[1], engine.chiefs[1]);
			PostCloneCardsList(source.chiefs[0].Cards.GetAll());
			PostCloneCardsList(source.chiefs[1].Cards.GetAll());
		}

		internal Engine.ClonedEngine GetClone ()
		{
			return engine;
		}

		private void PostCloneCardsList (List<Card> list)
		{
			foreach (Card source in list) {
				PostCloneCard(engine.cache.Get(source.Id), source);
			}
		}

		private void PostCloneCard (Card target, Card source)
		{
			target.Abilities.CloneFrom(source.Abilities);
			target.Modifiers.CloneFrom(source.Modifiers, engine);
		}

		private void PreCloneChief (Chief source, Chief target)
		{
			target.SetResources(source.GetResources());

			foreach (Card card in source.Cards.GetAll()) {
				PreCloneCard(card, target);
			}
		}

		private void PreCloneCard (Card card, Chief chief)
		{
			var clone = card.CloneFor(chief);

			engine.cache.ManualRegister(clone, card.Id);
			chief.Cards.Add(clone);
		}
	}
}
