using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
	public class WeaponCannon : Weapon
	{
		public override Status ValidateRange (FieldCard target)
		{
			if (!GetCard().GetFieldLocation().GetCell().IsAdjoiningTo(target.GetFieldLocation().GetCell())) {
				return Status.TargetIsTooFar;
			}

			return Status.Success;
		}
	}
}
