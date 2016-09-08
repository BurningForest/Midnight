using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.Triggers
{
    public class CardAutoDraw : Trigger, IListener<Before<BeginTurn>>
    {
        protected int Count = 1;

        public CardAutoDraw SetCount(int count)
        {
            Count = count;
            return this;
        }

        public int GetCount()
        {
            return Count;
        }

        public void On(Before<BeginTurn> ev)
        {
            var action = ev.Action;

            if (!action.IsInitial() && IsOwner(action.Chief))
            {
                action.AddChild(new DrawCount(action.Chief, Count));
            }
        }
    }
}
