using Midnight.Engine.ActionManager;
using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Core;

namespace Midnight.Engine.Actions
{
	public class StartGame : Action<StartGame>
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
