using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.Triggers
{
	public class FinalDeckOut : FinalTrigger, IListener<Failure<DrawRandom>>
	{
		public void On (Failure<DrawRandom> ev)
		{
			var chief = ev.action.chief.GetOpponent();

			if (IsOwner(chief)) {
				Win(chief);
			}
		}
	}
}
