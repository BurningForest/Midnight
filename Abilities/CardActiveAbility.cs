using Midnight.Cards;
using Midnight.Core;
using Midnight.Emitter;

namespace Midnight.Abilities
{
	public abstract class CardActiveAbility<TCard> : CardAbility<TCard>
		where TCard : Card
	{
		protected int quantity = 0;

		public int GetQuantity ()
		{
			return quantity;
		}

		public virtual int GetMaxQuantity ()
		{
			return 1;
		}

		public virtual bool IsUsed ()
		{
			return GetQuantity() >= GetMaxQuantity();
		}

		public abstract Status Validate ();
	}
}
