using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.Tests.Triggers
{
	internal class FinalListener : IListener<After<Final>>
	{
		public Final action = null;
		public int count = 0;

		public FinalListener (Engine engine)
		{
			engine.emitter.Subscribe(this);
		}

		public void On (After<Final> ev)
		{
			++count;

			if (action == null) {
				action = ev.action;
			}
		}
	}
}
