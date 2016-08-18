using Midnight.ActionManager;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class DrawRandom : GameAction<DrawRandom>
	{
		public readonly Chief Chief;

		public DrawRandom (Chief chief)
		{
			Chief = chief;
		}

		public override void Configure ()
		{
			AddChild(new Draw(Chief.cards.GetRandomDeckCard()));
		}

		public override Status Validation ()
		{
		    return Chief.cards.GetRandomDeckCard() == null ? Status.DeckIsEmpty : Status.Success;
		}
	}
}
