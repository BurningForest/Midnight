﻿using Midnight.Engine.Abilities.Aggression;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Cards.Vehicles
{
	public abstract class SpgVehicle : Vehicle
	{
		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(
				new Deployment(),
				new MovementMedium(),
				new WeaponArtillery(),
				new Attack()
			);
		}
	}
}