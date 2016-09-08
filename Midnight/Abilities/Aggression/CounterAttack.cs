namespace Midnight.Abilities.Aggression
{
	public class CounterAttack : Aggression
	{

		public class Joined : CounterAttack
		{
			private Attack GetJoinedAttack ()
			{
				return Card.Abilities.Get<Attack>();
			}

			public override int GetMaxQuantity ()
			{
				return GetJoinedAttack().GetMaxQuantity();
			}

			public override bool IsUsed ()
			{
				return GetJoinedAttack().GetQuantity() + GetQuantity() >= GetMaxQuantity();
			}
		}

		public class Infinity : CounterAttack
		{
			public override bool IsUsed ()
			{
				return false;
			}
		}

	}
}
