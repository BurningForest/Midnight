namespace Midnight.Cards.Types
{
	public abstract class ForefrontCard : Card
	{
		public override bool IsActive ()
		{
			return GetLocation().IsForefront();
		}
	}
}
