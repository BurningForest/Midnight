using Midnight.ActionManager;
using Midnight.ChiefOperations;

namespace Midnight.Actions
{
	public class SetResources : GameAction<SetResources>
	{
		public readonly Chief Chief;
		public readonly int Value;

		public SetResources (Chief chief, int value)
		{
			Chief = chief;
			Value = value;
		}

		public override void Configure ()
		{
			Chief.SetResources( Value );
		}
	}
}
