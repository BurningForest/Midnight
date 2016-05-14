namespace Midnight.Engine.Cards
{
	public abstract class Vehicle : FieldCard
	{
		public override bool IsActiveVehicle ()
		{
			return IsAtBattlefield();
		}
	}
}
