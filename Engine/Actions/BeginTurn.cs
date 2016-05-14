using Midnight.Engine.ActionManager;
using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Core;

namespace Midnight.Engine.Actions
{
	public class BeginTurn : Action
	{
		public readonly Chief chief;
		public readonly EndTurn turnEnd;

		public BeginTurn (Chief chief)
		{
			this.chief = chief;
			this.turnEnd = null;
		}

		public BeginTurn (Chief chief, EndTurn turnEnd)
		{
			this.chief = chief;
			this.turnEnd = turnEnd;
		}

		public bool IsInitial ()
		{
			return turnEnd == null;
		}

		public override void Configure ()
		{
			// todo turn
			// todo spotted
		}

		public override Status Validation ()
		{
			// todo isTurnOwner

			return Status.Success;
		}
	}
}
