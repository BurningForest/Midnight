using Midnight.Emitter;
using Midnight.ChiefOperations;

namespace Midnight.Triggers
{
	public abstract class Trigger : IListener
	{
		public Engine engine { get; private set; }
		public Chief chief { get; private set; }

		public void SetEngine (Engine engine)
		{
			this.engine = engine;

			engine.emitter.Subscribe(this);
		}

		public void SetChief (Chief chief)
		{
			this.chief = chief;
		}

		public bool IsOwner (Chief chief)
		{
			if (this.chief == null) {
				return true;
			}

			return chief == this.chief;
		}

		public Trigger CloneFor (Engine engine, Chief chief)
		{
			var clone = (Trigger) MemberwiseClone();
			clone.SetChief(chief);
			clone.SetEngine(engine);
			return clone;
		}
	}
}
