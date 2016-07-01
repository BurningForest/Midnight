using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class PayResources : GameAction<PayResources>
	{
		public readonly Chief chief;
		public readonly int value;

		public static PayResources ForCard (Card card)
		{
			return new PayResources(card.GetChief(), card.GetCost());
		}

		public PayResources (Chief chief, int value)
		{
			this.chief = chief;
			this.value = value;
		}

		public override void Configure ()
		{
			chief.PayResources( value );
		}

		public override Status Validation ()
		{
			if (chief.GetResources() < value) {
				return Status.NotEnoughResources;
			}

			return Status.Success;
		}
	}
}
