using Midnight.ActionManager;
using Midnight.ChiefOperations;

namespace Midnight.Actions
{
	public class StartGame : GameAction<StartGame>
	{
		public readonly Chief Chief;

		public StartGame (Chief chief)
		{
			Chief = chief;
		}

		public override void Configure ()
		{
			GetEngine().turn.StartWith(Chief);
			AddChild(new BeginTurn(Chief));
		}
	}
}
