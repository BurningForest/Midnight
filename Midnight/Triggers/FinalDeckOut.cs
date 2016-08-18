using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.ChiefOperations;
using Midnight.Emitter;

namespace Midnight.Triggers
{
	public class FinalDeckOut : Trigger, IListener<Failure<DrawRandom>>
	{
		public void On (Failure<DrawRandom> ev)
		{
			var chief = ev.Action.Chief.GetOpponent();

			if (IsOwner(chief)) {
				engine.actions.Delay(new Final(chief, Final.Trigger.DeckOut));
			}
		}
	}
}
