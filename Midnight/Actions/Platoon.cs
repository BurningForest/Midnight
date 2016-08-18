using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class ActivatePlatoon : GameAction<ActivatePlatoon>
	{
		public readonly Platoon Card;
		public readonly int Value;

		public ActivatePlatoon (Platoon card, int value)
		{
			Card  = card;
			Value = value;
		}

		public override void Configure ()
		{
			AddChild(new DealDamage(Value, Card, Card));
		}
	}
}
