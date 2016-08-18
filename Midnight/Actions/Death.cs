using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Death : GameAction<Death>
	{
        public readonly Card Card;
        public class Forced : Death
		{
			public Forced (Card card) : base(card) {}

			public override Status Validation ()
			{
				return Status.Success;
			}
		}
		public Death (Card card)
		{
			Card = card;
		}

		public override void Configure ()
		{
			Card.GetLocation().ToGraveyard();

			GetEngine().lantern.RecountTo(this);
		}

		public override Status Validation ()
		{
		    return Card.GetLives() > 0 ? Status.CardHasLives : Status.Success;
		}
	}
}
