using Midnight.Abilities.Positioning;
using Midnight.Cards.Enums;

namespace Midnight.Cards.Types
{
	public abstract class Platoon : ForefrontCard
	{
		public abstract class Enforce : Platoon { }
		public abstract class Protect : Platoon { }

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
