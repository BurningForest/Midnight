using Midnight.Engine.Abilities;
using Midnight.Engine.Abilities.Positioning;

namespace Midnight.Engine.Cards.Vehicles
{
	public abstract class SpatgVehicle : Vehicle
    {
        public override CardAbility[] CreateAbilities ()
        {
            return new CardAbility[] {
                new Deployment(),
                new MovementMedium()
            };
        }
    }
}
