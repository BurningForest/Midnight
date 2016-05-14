using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Abilities.Aggression
{
	public class WeaponCannon : Weapon
	{
		public override Status ValidateRange (FieldCard target)
		{
			if (!GetCard().GetCell().IsAdjoiningTo(target.GetCell())) {
				return Status.TargetIsNotAdjoining;
			}

			return Status.Success;
		}
	}
}
