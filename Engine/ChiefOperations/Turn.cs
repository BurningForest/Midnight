using System;
using Midnight.ActionManager.Events;
using Midnight.Emitter;
using Midnight.Actions;

namespace Midnight.ChiefOperations
{
	public class Turn : IListener<After<EndTurn>>
	{
		private readonly Engine engine;
		private int number = 0;
		private Chief owner;

		public Turn (Engine engine)
		{
			this.engine = engine;

			engine.emitter.Subscribe(this);
		}

		public int GetNumber ()
		{
			return number;
		}

		public void StartWith (Chief chief)
		{
			if (owner != null) {
				throw new Exception("Already started");
			}

			owner = chief;
		}

		private void ChangeOwner ()
		{
			owner = owner.GetOpponent();
			++number;
		}

		public Chief GetOwner ()
		{
			return owner;
		}

		public void On (After<EndTurn> ev)
		{
			ChangeOwner();
			engine.actions.Delay(new BeginTurn(GetOwner(), ev.action));
		}
	}
}
