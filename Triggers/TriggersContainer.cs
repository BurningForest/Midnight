using System.Collections.Generic;

namespace Midnight.Triggers
{
	public class TriggersContainer
	{
		private readonly Engine engine;
		private readonly List<Trigger> triggers = new List<Trigger>();

		public TriggersContainer (Engine engine)
		{
			this.engine = engine;
		}

		public TriggersContainer Register<TTrigger> ()
			where TTrigger : Trigger, new()
		{
			return Register(new TTrigger());
		}

		public TriggersContainer Register (Trigger trigger)
		{
			triggers.Add(trigger);
			trigger.SetEngine(engine);
			return this;
		}

		public List<Trigger> GetAll () {
			return triggers;
		}
	}
}
