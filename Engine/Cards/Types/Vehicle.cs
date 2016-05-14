namespace Midnight.Engine.Cards.Types
{
	public abstract class Vehicle : FieldCard
	{
		public override bool IsActiveVehicle ()
		{
			return IsAtBattlefield();
		}
	}
}
