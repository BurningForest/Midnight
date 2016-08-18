using Midnight.ChiefOperations;
using System.Collections.Generic;

namespace Midnight.Triggers
{
    public class TriggersContainer
    {
        private readonly Engine _engine;
        private readonly List<Trigger> _triggers = new List<Trigger>();

        public TriggersContainer(Engine engine)
        {
            _engine = engine;
        }

        public TTrigger Register<TTrigger>()
            where TTrigger : Trigger, new()
        {
            return Register(new TTrigger());
        }

        public TTrigger Register<TTrigger>(Chief chief)
            where TTrigger : Trigger, new()
        {
            var trigger = new TTrigger();
            trigger.SetChief(chief);
            return Register(trigger);
        }

        public TTrigger Register<TTrigger>(TTrigger trigger)
            where TTrigger : Trigger
        {
            _triggers.Add(trigger);
            trigger.SetEngine(_engine);
            return trigger;
        }

        public List<Trigger> GetAll()
        {
            return _triggers;
        }

        public void CloneFrom(TriggersContainer source)
        {
            foreach (var trigger in source._triggers)
            {
                var chief = trigger.Chief == null ? null : _engine.Chiefs[trigger.Chief.Index];
                Register(trigger.CloneFor(_engine, chief));
            }
        }
    }
}
