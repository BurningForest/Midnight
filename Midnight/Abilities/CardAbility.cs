using Midnight.Cards;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Emitter;
using System;

namespace Midnight.Abilities
{

	public abstract class CardAbility : IListener
	{
		protected Card Card;
		protected Chief Chief;
		protected Engine Engine;

		public void On (IEvent ev) { }

		internal void SetOwner (Card owner)
		{
			if (!IsValidCard(owner))
            {
				throw new ArgumentException("Ability does not support this card");
			}

			Card = owner;
			Chief = Card.GetChief();
			Engine = Chief.GetEngine();

			Engine.emitter.Subscribe(this);
		}

		protected abstract bool IsValidCard (Card card);

		public virtual bool IsActive ()
		{
			return true;
		}

		public virtual Status Validate ()
		{
			return Status.Success;
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
			return (TCard)Card;
		}
	}
}
