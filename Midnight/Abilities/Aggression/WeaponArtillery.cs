﻿using Midnight.Abilities.Passive;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
	public class WeaponArtillery : Weapon
	{
		public override Status ValidateRange (FieldCard target)
		{
			if (target.Abilities.Has<Camouflage>())
            {
				return Status.TargetIsUnderCamouflage;
			}

			return !target.IsSpotted() ? Status.TargetIsNotSpotted : Status.Success;
		}
	}
}
