using Midnight.Engine.Cards;
using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Emitter;
using System;

namespace Midnight.Engine.Abilities
{

	public abstract class CardAbility : IListener
	{
		protected Card card;
		protected Chief chief;
		protected Engine engine;

        public void On (IEvent ev) { }

		public void Configure (Card card, Chief chief, Engine engine)
		{
			if (!IsValidCard(card)) {
				throw new ArgumentException("Ability does not support this card");
			}

			this.card = card;
			this.chief = chief;
			this.engine = engine;

			engine.emitter.Subscribe(this);
		}

		protected virtual bool IsValidCard (Card card)
		{
			return true;
		}

	}

	public abstract class CardAbility<TCard> : CardAbility
		where TCard : Card
	{
		protected override bool IsValidCard (Card card)
		{
			return card is TCard;
		}

		public TCard GetCard ()
		{
			return (TCard)card;
		}
	}
}
