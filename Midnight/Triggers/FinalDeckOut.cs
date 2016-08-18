using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.Triggers
{
    public class FinalDeckOut : Trigger, IListener<Failure<DrawRandom>>
    {
        public void On(Failure<DrawRandom> ev)
        {
            var opponent = ev.Action.Chief.GetOpponent();

            if (IsOwner(opponent))
            {
                Engine.actions.Delay(new Final(opponent, Final.Trigger.DeckOut));
            }
        }
    }
}
