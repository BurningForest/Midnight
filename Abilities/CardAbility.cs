using Midnight.Cards;
using Midnight.ChiefOperations;
using Midnight.Emitter;
using System;

namespace Midnight.Abilities
{

	public abstract class CardAbility : IListener
	{
		protected Card card;
		protected Chief chief;
		protected Engine engine;

		public void On (IEvent ev) { }

		internal void SetOwner (Card owner)
		{
			if (!IsValidCard(owner)) {
				throw new ArgumentException("Ability does not support this card");
			}

			card = owner;
			chief = card.GetChief();
			engine = chief.GetEngine();

			engine.emitter.Subscribe(this);
		}

		protected abstract bool IsValidCard (Card card);

		public virtual bool IsActive ()
		{
			return true;
		}

		public virtual CardAbility CloneFor (Card card)
		{
			var clone = (CardAbility)MemberwiseClone();
			clone.SetOwner(card);
			return clone;
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
