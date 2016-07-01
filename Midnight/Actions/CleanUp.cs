using Midnight.ActionManager;
using Midnight.Cards.Enums;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class CleanUp : GameAction<CleanUp>
	{
		public readonly Chief chief;
		public readonly int count;

		public CleanUp (Chief chief, int count)
		{
			this.chief = chief;
			this.count = count;
		}

		public override void Configure ()
		{
			var reserve = chief.cards.FromLocationShuffled(Location.reserve);
			var shuffle = System.Math.Min(count, reserve.Count);

			for (var i = 0; i < shuffle; i++) {
				AddChild(new Death.Forced(reserve[i]));
			}
		}
	}
}
