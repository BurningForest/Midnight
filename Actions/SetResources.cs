using Midnight.ActionManager;
using Midnight.ChiefOperations;

namespace Midnight.Actions
{
	public class SetResources : GameAction<SetResources>
	{
		public readonly Chief chief;
		public readonly int value;

		public SetResources (Chief chief, int value)
		{
			this.chief = chief;
			this.value = value;
		}

		public override void Configure ()
		{
			chief.SetResources( value );
		}
	}
}
