using Midnight.Abilities.Aggression;
using Midnight.Abilities.Passive;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Cards.Vehicles
{
	public abstract class SpatgVehicle : Vehicle
	{
		public override void InitAbilities ()
		{
			base.InitAbilities();

			Abilities.Add(
				new Deployment(),
				new MovementMedium(),
				new WeaponCannon(),
				new Attack(),
				new CounterAttack(),
				new FirstStrike()
			);
		}
	}
}
