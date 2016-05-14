using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Enums;

namespace Midnight.Engine.Cards.Types
{
	public abstract class Platoon : ForefrontCard
	{
		public abstract class AttackPlatoon : Platoon { }
		public abstract class DefensePlatoon : Platoon { }

		public static Subtype[] subtypeOrder = {
			Subtype.scout,
			Subtype.communications,
			Subtype.artillery,
			Subtype.medic,
			Subtype.intendancy,
		};

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(
				new Deployment()
			);
		}
	}
}
