using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class ActivatePlatoon : GameAction<ActivatePlatoon>
	{
		public readonly Platoon card;
		public readonly int value;

		public ActivatePlatoon (Platoon card, int value)
		{
			this.card  = card;
			this.value = value;
		}

		public override void Configure ()
		{
			AddChild(new DealDamage(value, card, card));
		}
	}
}
