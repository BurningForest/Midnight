using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
	abstract public class Weapon : CardAbility<FieldCard>
	{
		public Status Validate (FieldCard target)
		{
            if (!GetCard().GetFieldLocation().IsBattlefield())
            {
                return Status.NotAtBattlefield;
            }

            if (!target.GetFieldLocation().IsBattlefield())
            {
				return Status.NotAtBattlefield;
			}

			return !Card.IsEnemyOf(target) ? Status.TargetIsFriendly : ValidateRange(target);
		}

		public abstract Status ValidateRange (FieldCard target);
	}
}
