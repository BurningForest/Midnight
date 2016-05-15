using Midnight.Abilities.Aggression;
using Midnight.Abilities.Positioning;
using Midnight.Cards.Types;

namespace Midnight.Cards.Vehicles
{
	public abstract class HeavyVehicle : Vehicle
	{
		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(
				new Deployment(),
				new MovementSlow(),
				new WeaponCannon(),
				new Attack(),
				new CounterAttack.Joined()
			);
		}
	}
}
