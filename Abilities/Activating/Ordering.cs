using System;
using System.Collections.Generic;
using Midnight.ActionManager;
using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.Core;
using Midnight.Emitter;

namespace Midnight.Abilities.Activating
{
	public class Ordering : CardActiveAbility<Card>, IListener<Before<BeginTurn>>
	{

		public SpecificAbility GetSpecificAbility ()
		{
			return card.abilities.Get<SpecificAbility>();
		}

		public bool CanActivateOn (Card card)
		{
			var ability = GetSpecificAbility();

			return ability.CanTargetCards()
				&& ability.GetTargets().IsValid(card);
		}

		public Card[] GetPotentialTargets ()
		{
			var ability = GetSpecificAbility();

			return ability.CanTargetCards()
				? ability.GetTargets().GetAll()
				: null;
		}

		internal IEnumerable<GameAction> Activate (FieldCard target)
		{
			return GetSpecificAbility().GetActions(target);
		}

		public void On (Before<BeginTurn> ev)
		{
			if (card.IsControlledBy(ev.action.chief)) {
				quantity = 0;
			}
		}

		public override Status Validate ()
		{
			return Validate(null);
		}

		public Status Validate (ForefrontCard target)
		{
			if (!chief.IsTurnOwner()) {
				return Status.NotTurnOfSource;
			}

			if (!card.GetLocation().IsReserve()) {
				return Status.NotAtReserve;
			}

			if (!card.abilities.Has<SpecificAbility>()) {
				return Status.NoSpecificAbility;
			}

			var ability = GetSpecificAbility();

			if (target == null && NoValidTargets()) {
				return Status.NoValidTargets;
			}

			if (target != null && !CanActivateOn(target)) {
				return Status.TargetIsInvalid;
			}

			return PayResources.ForCard(card).Validation();
		}

		private bool NoValidTargets ()
		{
			var ability = GetSpecificAbility();

			return ability.CanTargetCards() && !ability.GetTargets().IsValidExists();
		}
	}
}
