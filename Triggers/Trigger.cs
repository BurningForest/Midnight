using Midnight.Emitter;

namespace Midnight.Triggers
{
	public abstract class Trigger : IListener
	{
		public Engine engine { get; private set; }

		public void SetEngine (Engine engine)
		{
			this.engine = engine;

			engine.emitter.Subscribe(this);
		}
	}
}
