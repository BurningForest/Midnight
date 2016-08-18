using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.Triggers
{
	public class TurnAddResources : Trigger, IListener<Before<BeginTurn>>
	{
		public void On (Before<BeginTurn> ev)
		{
			if (!IsOwner(ev.action.Chief)) {
				return;
			}

			ev.action.AddChild(
				new SetResources(
					ev.action.Chief,
					ev.action.Chief.GetTotalIncrease()
				)
			);
		}
	}
}
