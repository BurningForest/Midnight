using Midnight.Abilities.Positioning;
using Midnight.Cards.Enums;
using Sun.CardProtos.Enums;

namespace Midnight.Cards.Types
{
	public abstract class Platoon : ForefrontCard
	{
		public abstract class Enforce : Platoon { }
		public abstract class Protect : Platoon { }

		public static Subtype[] subtypeOrder = {
			Subtype.Scout,
			Subtype.Communications,
			Subtype.Artillery,
			Subtype.Medic,
			Subtype.Intendancy,
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
