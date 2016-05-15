using System;
using Midnight.Engine.Core;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Emitter;
using Midnight.Engine.Actions;
using Midnight.Engine.ActionManager.Events;

namespace Midnight.Engine.Abilities.Aggression
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
