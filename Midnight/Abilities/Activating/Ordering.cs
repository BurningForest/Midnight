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
			return Card.abilities.Get<SpecificAbility>();
		}

		public bool CanActivateOn (Card targetCard)
		{
			var ability = GetSpecificAbility();

			return ability.CanTargetCards()
				&& ability.GetTargets().IsValid(targetCard);
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
			if (Card.IsControlledBy(ev.action.chief)) {
				Quantity = 0;
			}
		}

		public override Status Validate ()
		{
			return Validate(null);
		}

		public Status Validate (ForefrontCard target)
		{
			if (!Chief.IsTurnOwner())
            {
				return Status.NotTurnOfSource;
			}

			if (!Card.GetLocation().IsReserve())
            {
				return Status.NotAtReserve;
			}

			if (!Card.abilities.Has<SpecificAbility>())
            {
				return Status.NoSpecificAbility;
			}

			var ability = GetSpecificAbility();

			if (target == null && NoValidTargets())
            {
				return Status.NoValidTargets;
			}

			if (target != null && !CanActivateOn(target))
            {
				return Status.TargetIsInvalid;
			}

			return PayResources.ForCard(Card).Validation();
		}

		private bool NoValidTargets ()
		{
			var ability = GetSpecificAbility();

			return ability.CanTargetCards() && !ability.GetTargets().IsValidExists();
		}
	}
}
