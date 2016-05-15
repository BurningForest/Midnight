using Midnight.ActionManager;
using Midnight.Cards.Props;
using Midnight.Core;

namespace Midnight.Actions
{
	public class AddModifier : GameAction<AddModifier>
	{
		private readonly Modifier modifier;

		public AddModifier (Modifier modifier) {
			this.modifier = modifier;
		}

		public override void Configure ()
		{
			modifier.GetTarget().Modify(modifier);
		}

		public override Status Validation ()
		{
			if (modifier.GetTarget().IsDead()) {
				return Status.TargetIsDead;
			}

			return Status.Success;
		}
	}
}
