using Midnight.Abilities.Aggression;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Cards.Vehicles
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
