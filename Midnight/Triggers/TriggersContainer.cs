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

		public TTrigger Register<TTrigger> ()
			where TTrigger : Trigger, new()
		{
			return Register(new TTrigger());
		}

		public TTrigger Register<TTrigger> (Chief chief)
			where TTrigger : Trigger, new()
		{
			var trigger = new TTrigger();
			trigger.SetChief(chief);
			return Register(trigger);
		}

		public TTrigger Register<TTrigger> (TTrigger trigger)
			where TTrigger : Trigger
		{
			triggers.Add(trigger);
			trigger.SetEngine(engine);
			return trigger;
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
