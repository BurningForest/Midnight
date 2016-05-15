using System.Collections.Generic;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Abilities.Aggression;

namespace Midnight.Engine.Cards.Types
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
