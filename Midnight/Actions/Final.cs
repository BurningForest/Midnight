using Midnight.ActionManager;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Final : GameAction<Final>
	{
        public readonly Chief Winner;
        // Does not match naming rule, but can't rename it, cause it conflicts with enum
        public readonly Trigger trigger;
        public enum Trigger
		{
			HqDeath,
			DeckOut,
			Surrender
		};
		public Final (Chief winner, Trigger trigger)
		{
			Winner = winner;
			this.trigger = trigger;
		}

		public override void Configure ()
		{
			Winner.GetEngine().Finish(this);
		}

		public override Status Validation ()
		{
		    return Winner.GetEngine().final != null ? Status.GameIsFinished : Status.Success;
		}
	}
}
