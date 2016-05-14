using Midnight.Engine.ActionManager;
using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Core;

namespace Midnight.Engine.Actions
{
	public class StartGame : Action
	{
		public readonly Chief chief;

		public StartGame (Chief chief)
		{
			this.chief = chief;
		}

		public override void Configure ()
		{
			AddChild(new BeginTurn(chief));
		}
	}
}
