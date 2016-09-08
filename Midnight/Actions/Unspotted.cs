using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Unspotted : GameAction<Unspotted>
	{
		public readonly FieldCard Card;

		public Unspotted (FieldCard card)
		{
			Card = card;
		}
	}
}
