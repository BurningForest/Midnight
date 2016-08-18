using Midnight.ActionManager;
using Midnight.ChiefOperations;

namespace Midnight.Actions
{
	public class DrawCount : GameAction<DrawCount>
	{
		public readonly Chief Chief;
		public readonly int Count;

		public DrawCount (Chief chief, int count)
		{
			Chief = chief;
			Count = count;
		}

		public override void Configure ()
		{
			for (int i = 0; i < Count; i++)
            {
				AddChild(new DrawRandom(Chief));
			}
		}
	}
}
