using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Abilities.Aggression
{
	public class CounterAttack : Aggression
	{

		public class Joined : CounterAttack
		{
			private Attack GetJoinedAttack ()
			{
				return card.abilities.Get<Attack>();
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
