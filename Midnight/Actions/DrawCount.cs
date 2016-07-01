using Midnight.ActionManager;
using Midnight.ChiefOperations;

namespace Midnight.Actions
{
	public class DrawCount : GameAction<DrawCount>
	{
		public readonly Chief chief;
		public readonly int count;

		public DrawCount (Chief chief, int count)
		{
			this.chief = chief;
			this.count = count;
		}

		public override void Configure ()
		{
			for (int i = 0; i < count; i++) {
				AddChild(new DrawRandom(chief));
			}
		}
	}
}
