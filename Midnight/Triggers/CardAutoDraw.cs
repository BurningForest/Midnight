using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;
namespace Midnight.Triggers
{
	public class CardAutoDraw : Trigger, IListener<Before<BeginTurn>>
	{
		protected int count = 1;

		public CardAutoDraw SetCount (int count)
		{
			this.count = count;
			return this;
		}

		public int GetCount ()
		{
			return count;
		}

		public void On (Before<BeginTurn> ev)
		{
			BeginTurn action = ev.action;
			
			if (!action.IsInitial() && IsOwner(action.chief)) {
				action.AddChild(new DrawCount(action.chief, count)); 
			}
		}
	}
}
