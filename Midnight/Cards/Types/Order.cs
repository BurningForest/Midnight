using Midnight.Abilities.Activating;

namespace Midnight.Cards.Types
{
	public abstract class Order : Card
	{
		public override void InitAbilities ()
		{
			base.InitAbilities();
			
			abilities.Add(new Ordering());
		}
	}
}
