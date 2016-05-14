using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Abilities.Aggression
{
	public class WeaponArtillery : Weapon
	{
		public override Status ValidateRange (FieldCard target)
		{
			// todo: Camouflage

			// todo: spotted

			return Status.Success;
		}
	}
}
