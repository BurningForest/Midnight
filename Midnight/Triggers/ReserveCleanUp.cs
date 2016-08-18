using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Cards.Enums;
using Midnight.Emitter;
namespace Midnight.Triggers
{
	public class ReserveCleanUp : Trigger, IListener<Before<EndTurn>>
	{
		protected int max = 6;

		public ReserveCleanUp SetMax (int max)
		{
			this.max = max;
			return this;
		}

		public int GetMax ()
		{
			return max;
		}

		public void On (Before<EndTurn> ev)
		{
			EndTurn action = ev.action;

			if (!IsOwner(action.Chief)) {
				return;
			}

			var diff = action.Chief.cards.CountLocation(Location.Reserve) - max;

			if (diff > 0) {
				action.AddChild(new CleanUp(action.Chief, diff));
			}
		}
	}
}
