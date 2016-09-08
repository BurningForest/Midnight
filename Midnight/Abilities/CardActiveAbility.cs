using Midnight.Cards;

namespace Midnight.Abilities
{
	public abstract class CardActiveAbility<TCard> : CardAbility<TCard>
		where TCard : Card
	{
		protected int Quantity = 0;

		public int GetQuantity ()
		{
			return Quantity;
		}

		public virtual int GetMaxQuantity ()
		{
			return 1;
		}

		public virtual bool IsUsed ()
		{
			return GetQuantity() >= GetMaxQuantity();
		}
	}
}
