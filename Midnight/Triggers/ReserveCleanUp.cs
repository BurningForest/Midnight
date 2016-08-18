using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Cards.Enums;
using Midnight.Emitter;

namespace Midnight.Triggers
{
    public class ReserveCleanUp : Trigger, IListener<Before<EndTurn>>
    {
        protected int Max = 6;

        public ReserveCleanUp SetMax(int max)
        {
            Max = max;
            return this;
        }

        public int GetMax()
        {
            return Max;
        }

        public void On(Before<EndTurn> ev)
        {
            var action = ev.Action;

            if (!IsOwner(action.Chief))
            {
                return;
            }

            var diff = action.Chief.Cards.CountLocation(Location.Reserve) - Max;

            if (diff > 0)
            {
                action.AddChild(new CleanUp(action.Chief, diff));
            }
        }
    }
}
