using Midnight.ActionManager;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class StartGame : GameAction<StartGame>
	{
		public readonly Chief chief;

		public StartGame (Chief chief)
		{
			this.chief = chief;
		}

		public override void Configure ()
		{
			GetEngine().turn.StartWith(chief);
			AddChild(new BeginTurn(chief));
		}
	}
}
