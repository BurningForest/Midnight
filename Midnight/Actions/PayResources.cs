using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class PayResources : GameAction<PayResources>
	{
		public readonly Chief Chief;
		public readonly int Value;

		public static PayResources ForCard (Card card)
		{
			return new PayResources(card.GetChief(), card.GetCost());
		}

		public PayResources (Chief chief, int value)
		{
			Chief = chief;
			Value = value;
		}

		public override void Configure ()
		{
			Chief.PayResources( Value );
		}

		public override Status Validation ()
		{
		    return Chief.GetResources() < Value ? Status.NotEnoughResources : Status.Success;
		}
	}
}
