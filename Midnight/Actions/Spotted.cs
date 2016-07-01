using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Spotted : GameAction<Spotted>
	{
		public readonly FieldCard card;

		public Spotted (FieldCard card)
		{
			this.card = card;
		}
	}
}
