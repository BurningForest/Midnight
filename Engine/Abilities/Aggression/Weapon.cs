using System;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Abilities.Aggression
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
