using Midnight.Engine.Abilities;
using Midnight.Engine.Abilities.Positioning;

namespace Midnight.Engine.Cards.Vehicles
{
	public abstract class LightVehicle : Vehicle
	{
		public override CardAbility[] CreateAbilities ()
		{
			return new CardAbility[] {
				new Deployment(),
				new MovementFast()
			};
		}
	}
}
