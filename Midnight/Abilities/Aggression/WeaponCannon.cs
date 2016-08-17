using System;
using Midnight.Battlefield;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
    public class WeaponCannon : Weapon
    {
        public override Status ValidateRange(FieldCard target)
        {
            return !GetCard().GetFieldLocation().GetCell().IsAdjoiningTo(target.GetFieldLocation().GetCell()) ? Status.TargetIsTooFar : Status.Success;
        }
    }
}
