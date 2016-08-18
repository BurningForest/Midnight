using Midnight.ActionManager;
using Midnight.Cards.Enums;
using Midnight.ChiefOperations;

namespace Midnight.Actions
{
	public class CleanUp : GameAction<CleanUp>
	{
		public readonly Chief Chief;
		public readonly int Count;

		public CleanUp (Chief chief, int count)
		{
			Chief = chief;
			Count = count;
		}

		public override void Configure ()
		{
			var reserve = Chief.cards.FromLocationShuffled(Location.Reserve);
			var shuffle = System.Math.Min(Count, reserve.Count);

			for (var i = 0; i < shuffle; i++)
            {
				AddChild(new Death.Forced(reserve[i]));
			}
		}
	}
}
