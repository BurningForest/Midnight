﻿namespace Midnight.Cards.Types
{
	public abstract class Vehicle : FieldCard
	{
		public override bool IsActive ()
		{
			return GetFieldLocation().IsBattlefield();
		}
	}
}
