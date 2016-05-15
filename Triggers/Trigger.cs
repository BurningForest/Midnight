using System;
using Midnight.ChiefOperations;
using Midnight.Emitter;

namespace Midnight.Triggers
{
	public abstract class Trigger : IListener
	{
		public readonly Engine engine;
		public readonly Chief chief;

		public Trigger (Engine engine, Chief chief)
		{
			this.engine = engine;
			this.chief = chief;

			engine.emitter.Subscribe(this);
		}

		public bool IsCorrectChief (Chief chief)
		{
			return this.chief == chief;
		}

		private void Loser (Chief chief)
		{
			throw new NotImplementedException();
		}
	}
}
