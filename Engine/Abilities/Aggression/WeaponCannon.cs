using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Abilities.Aggression
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
