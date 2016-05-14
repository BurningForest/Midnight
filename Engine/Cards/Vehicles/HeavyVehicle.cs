using Midnight.Engine.Abilities.Aggression;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Cards.Vehicles
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
