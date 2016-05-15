using Midnight.Engine.Abilities.Passive;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Abilities.Aggression
{
	public class WeaponArtillery : Weapon
	{
		public override Status ValidateRange (FieldCard target)
		{
			if (target.abilities.Has<Camouflage>()) {
				return Status.TargetIsUnderCamouflage;
			}

			// todo: spotted

			return Status.Success;
		}
	}
}
