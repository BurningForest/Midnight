using System;
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
			if (IsUsed()) {
				return Status.AbilityIsUsed;
			}

			return Status.Success;
		}

		public Status Validate (FieldCard target)
		{
			var status = Validate();

			if (status != Status.Success) {
				return status;
			}

			return ValidateTarget(target);
		}

		public Status ValidateTarget (FieldCard target)
		{
			if (!card.GetLocation().IsForefront() || !target.GetFieldLocation().IsForefront()) {
				return Status.NotAtBattlefield;
			}

			return card.abilities.Get<Weapon>().Validate(target);
		}

		internal void Activate ()
		{
			++quantity;
		}

		public void On (Before<BeginTurn> ev)
		{
			if (card.IsControlledBy(ev.action.chief)) {
				quantity = 0;
			}
		}
	}
}
