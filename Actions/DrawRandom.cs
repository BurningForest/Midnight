using Midnight.ActionManager;
using Midnight.ChiefOperations;
using Midnight.Cards;
using Midnight.Core;

namespace Midnight.Actions
{
	public class DrawRandom : GameAction<Draw>
	{
		public readonly Chief chief;

		public DrawRandom (Chief chief)
		{
			this.chief = chief;
		}

		public override void Configure ()
		{
			AddChild(new Draw(chief.cards.GetRandomDeckCard()));
		}

		public override Status Validation ()
		{
			if (chief.cards.GetRandomDeckCard() == null) {
				return Status.DeckIsEmpty;
			}

			return Status.Success;
		}
	}
}
