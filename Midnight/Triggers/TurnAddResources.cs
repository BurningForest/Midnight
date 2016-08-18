using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.Triggers
{
	public class TurnAddResources : Trigger, IListener<Before<BeginTurn>>
	{
		public void On (Before<BeginTurn> ev)
		{
			if (!IsOwner(ev.Action.Chief)) {
				return;
			}

			ev.Action.AddChild(
				new SetResources(
					ev.Action.Chief,
					ev.Action.Chief.GetTotalIncrease()
				)
			);
		}
	}
}
