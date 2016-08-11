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
            //This hotfix has an error in 2nd line. What we need to return if cell is null?
            //var cell = GetCard().GetFieldLocation().GetCell();
            //if (cell != null && !cell.IsAdjoiningTo(target.GetFieldLocation().GetCell())) return Status.TargetIsTooFar;

            //This is an original code
            /*if (!GetCard().GetFieldLocation().GetCell().IsAdjoiningTo(target.GetFieldLocation().GetCell()))
            {
                return Status.TargetIsTooFar;
            }*/

            //This is a LINQ-solution, made from original code
            return !GetCard().GetFieldLocation().GetCell().IsAdjoiningTo(target.GetFieldLocation().GetCell()) ? Status.TargetIsTooFar : Status.Success;
        }
    }
}
