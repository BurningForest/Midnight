using Midnight.Engine.ActionManager;
using Midnight.Engine.Cards.Props;
using Midnight.Engine.Cards.Types;

namespace Midnight.Engine.Actions
{
	public class DealDamage : GameAction<DealDamage>
	{
		private FieldCard source;
		private FieldCard target;
		private int value;

		public DealDamage (int value, FieldCard source, FieldCard target)
		{
			this.value = value;
			this.source = source;
			this.target = target;
		}
	}
}
