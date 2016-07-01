using Midnight.Abilities.Passive;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
	public class WeaponArtillery : Weapon
	{
		public override Status ValidateRange (FieldCard target)
		{
			if (target.abilities.Has<Camouflage>()) {
				return Status.TargetIsUnderCamouflage;
			}

			if (!target.IsSpotted()) {
				return Status.TargetIsNotSpotted;
			}

			return Status.Success;
		}
	}
}
