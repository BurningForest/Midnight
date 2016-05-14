﻿using Midnight.Engine.Abilities.Aggression;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Cards.Vehicles
{
	public abstract class LightVehicle : Vehicle
	{
		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(
				new Deployment(),
				new MovementFast(),
				new WeaponCannon(),
				new Attack(),
				new CounterAttack()
			);
		}
	}
}