using System.Collections.Generic;
using Midnight.Battlefield;
using Midnight.Abilities.Aggression;
using Midnight.Abilities.Passive;

namespace Midnight.Cards.Types
{
	public abstract class Hq : FieldCard
	{
		public List<Cell> GetFootholdCells ()
		{
			return GetFieldLocation().GetCell().GetAdjoiningCells();
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(
				new WeaponArtillery(),
				new Attack(),
				new PlatoonEnforced(),
				new PlatoonProtected()
			);
		}

		public override bool IsSpotted ()
		{
			// hq is always spotted
			return true;
		}
	}
}
