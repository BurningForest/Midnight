using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Spotted : GameAction<Step>
	{
		public readonly FieldCard card;

		public Spotted (FieldCard card)
		{
			this.card = card;
		}
	}
}
