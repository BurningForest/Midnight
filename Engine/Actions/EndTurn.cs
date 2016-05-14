using Midnight.Engine.ActionManager;
using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Core;

namespace Midnight.Engine.Actions
{
	public class EndTurn : Action<EndTurn>
	{
		public readonly Chief chief;

		public EndTurn (Chief chief)
		{
			this.chief = chief;
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
