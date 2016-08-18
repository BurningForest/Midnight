using Midnight.ActionManager;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class BeginTurn : GameAction<BeginTurn>
	{
		public readonly Chief Chief;
		public readonly EndTurn TurnEnd;

		public BeginTurn (Chief chief)
		{
			Chief = chief;
			TurnEnd = null;
		}

		public BeginTurn (Chief chief, EndTurn turnEnd)
		{
			Chief = chief;
			TurnEnd = turnEnd;
		}

		public bool IsInitial ()
		{
			return TurnEnd == null;
		}

		public override void Configure ()
		{
			GetEngine().Lantern.RecountTo(this);
		}

		public override Status Validation ()
		{
			return Status.Success;
		}
	}
}
