using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emitter;

namespace Program
{

    namespace Deploy
    {
        public interface Listener : IListener<Event> { }

        public class Event : Event<Listener, Event> { }
    }

    namespace Move
    {
        public interface Listener : IListener<Event> { }

        public class Event : Event<Listener, Event> { }
    }

    namespace Attack
    {
        public interface Listener : IListener<Event> { }

        public class Event : Event<Listener, Event> { }
    }

}
