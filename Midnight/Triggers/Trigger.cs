using Midnight.ChiefOperations;
using Midnight.Emitter;

namespace Midnight.Triggers
{
    public abstract class Trigger : IListener
    {
        public Engine Engine { get; private set; }
        public Chief Chief { get; private set; }

        public void SetEngine(Engine engine)
        {
            Engine = engine;

            engine.emitter.Subscribe(this);
        }

        public void SetChief(Chief chief)
        {
            Chief = chief;
        }

        public bool IsOwner(Chief chief)
        {
            if (Chief == null)
            {
                return true;
            }

            return chief == Chief;
        }

        public Trigger CloneFor(Engine engine, Chief chief)
        {
            var clone = (Trigger)MemberwiseClone();
            clone.SetChief(chief);
            clone.SetEngine(engine);
            return clone;
        }
    }
}
