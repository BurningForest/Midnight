using Midnight.Abilities.Activating;

namespace Midnight.Cards.Types
{
	public abstract class Order : Card
	{
		public override void InitAbilities ()
		{
			base.InitAbilities();
			
			Abilities.Add(new Ordering());
		}
	}
}
