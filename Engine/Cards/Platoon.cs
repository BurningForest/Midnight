namespace Midnight.Engine.Cards
{
	public abstract class Platoon : ForefrontCard
	{
		public void ToSupport ()
		{
			ToLocation(Location.support);
		}

		public override bool IsPlatoon ()
		{
			return true;
		}

		public static Subtype[] subtypeOrder = {
			Subtype.scout,
			Subtype.communications,
			Subtype.artillery,
			Subtype.medic,
			Subtype.intendancy,
		};

		public abstract class Defense : Platoon
		{
			public override bool IsDefense ()
			{
				return true;
			}
		}

		public abstract class Attack : Platoon
		{
			public override bool IsAttack ()
			{
				return true;
			}
		}
	}
}
