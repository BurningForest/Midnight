using System;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
	abstract public class Weapon : CardAbility<FieldCard>
	{
		public Status Validate (FieldCard target)
		{
			if (!target.GetFieldLocation().IsBattlefield()) {
				return Status.NotAtBattlefield;
			}

			if (!card.IsEnemyOf(target)) {
				return Status.TargetIsFriendly;
			}

			return ValidateRange(target);
		}

		public abstract Status ValidateRange (FieldCard target);
	}
}
