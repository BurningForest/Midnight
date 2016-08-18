using Midnight.ActionManager;
using Midnight.Cards.Props;
using Midnight.Core;

namespace Midnight.Actions
{
	public class AddModifier : GameAction<AddModifier>
	{
		public readonly Modifier Modifier;

		public AddModifier (Modifier modifier)
        {
			Modifier = modifier;
		}

		public override void Configure ()
		{
			Modifier.GetTarget().Modify(Modifier);
		}

		public override Status Validation ()
		{
		    return Modifier.GetTarget().IsDead() ? Status.TargetIsDead : Status.Success;
		}
	}
}
