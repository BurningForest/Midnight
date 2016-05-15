using System.Collections.Generic;
using Midnight.Battlefield;
using Midnight.Abilities.Aggression;

namespace Midnight.Cards.Types
{
	public abstract class Hq : FieldCard
	{
		public List<Cell> GetFootholdCells ()
		{
			return GetFieldLocation().GetCell().GetAdjoiningCells();
		}

		public override bool IsActive ()
		{
			return GetFieldLocation().IsBattlefield();
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(
				new WeaponArtillery(),
				new Attack()
			);
		}
	}
}
