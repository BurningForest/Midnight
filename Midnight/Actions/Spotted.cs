using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Spotted : GameAction<Spotted>
	{
		public readonly FieldCard Card;

		public Spotted (FieldCard card)
		{
			Card = card;
		}
	}
}
