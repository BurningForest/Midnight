using Midnight.ActionManager;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class EndTurn : GameAction<EndTurn>
	{
		public readonly Chief Chief;

		public EndTurn (Chief chief)
		{
			Chief = chief;
		}

		public override void Configure ()
		{
			// todo turn
		}

		public override Status Validation ()
		{
			// todo isTurnOwner
			return Status.Success;
		}
	}
}
