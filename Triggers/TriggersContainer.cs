using Midnight.ChiefOperations;
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
			return Register<TTrigger>(null);
		}

		public TriggersContainer Register<TTrigger> (Chief chief)
			where TTrigger : Trigger, new()
		{
			var trigger = new TTrigger();
			trigger.SetChief(chief);
			return Register(trigger);
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
		
		public void CloneFrom (TriggersContainer source)
		{
			foreach (var trigger in source.triggers) {
				var chief = trigger.chief == null ? null : engine.chiefs[trigger.chief.index];
				Register(trigger.CloneFor(engine, chief));
			}
		}
	}
}
