﻿using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Cards.Types;

namespace Midnight.Abilities.Activating
{
	public abstract class SpecificAbility : CardAbility<Card>
	{
		public bool CanTargetCards ()
		{
			return GetTargets() != null;
		}

		public Search GetTargets ()
		{
			return Targets(new Search(Chief));
		}

		public GameAction[] GetActions (ForefrontCard target)
		{
			return Actions(target);
		}

		protected abstract Search Targets (Search search);
		protected abstract GameAction[] Actions (ForefrontCard target);
	}
}
