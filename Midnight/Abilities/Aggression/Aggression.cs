using Midnight.Core;
using Midnight.Cards.Types;
using Midnight.Emitter;
using Midnight.Actions;
using Midnight.ActionManager.Events;

namespace Midnight.Abilities.Aggression
{
	public abstract class Aggression : CardActiveAbility<FieldCard>, IListener<Before<BeginTurn>>
	{
		public override Status Validate ()
		{
		    return IsUsed() ? Status.AbilityIsUsed : Status.Success;
		}

	    public Status Validate (FieldCard target)
		{
			var status = Validate();

			return status != Status.Success ? status : ValidateTarget(target);
		}

		public Status ValidateTarget (FieldCard target)
		{
			if (!Card.GetLocation().IsForefront() || !target.GetFieldLocation().IsForefront()) {
				return Status.NotAtBattlefield;
			}

			return Card.abilities.Get<Weapon>().Validate(target);
		}

		internal void Activate ()
		{
			++Quantity;
		}

		public void On (Before<BeginTurn> ev)
		{
			if (Card.IsControlledBy(ev.action.chief))
            {
				Quantity = 0;
			}
		}
	}
}
