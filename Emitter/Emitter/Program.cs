using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emitter;

namespace Program
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Hello");

            var events = new EventEmitter();

            events
                .AddSupport(new Deploy.Event())
                .AddSupport(new Move.Event())
                .AddSupport(new Attack.Event());

            events
                 .Subscribe(new MyListener("Foo"))
                 .To<Deploy.Event>()
                 .To<Move.Event>()
                 .To<Attack.Event>();

            events
                .Subscribe(new MyListener("Bar"))
                .To<Deploy.Event>()
                .To<Move.Event>();

            events.SubscribeToAll(new AnyListener());

            events.Publish(new Deploy.Event());
            events.Publish(new Move.Event());
            events.Publish(new Attack.Event());

            Console.ReadLine();
        }
    }



    public class MyListener :
        Deploy.Listener,
        Move.Listener,
        Attack.Listener
    {
        String name;

        public MyListener (String name)
        {
            this.name = name;
        }

        public void On (Deploy.Event e)
        {
            Console.WriteLine("({1}) OnDeploy: {0}", e, this.name);
        }

        public void On (Move.Event e)
        {
            Console.WriteLine("({1}) OnMove  : {0}", e, this.name);
        }

        public void On (Attack.Event e)
        {
            Console.WriteLine("({1}) OnAttack: {0}", e, this.name);
        }
    }

    public class AnyListener : IAllListener
    {
        public void On (IEvent e)
        {
            Console.WriteLine("Any event: {0}", e);
        }
    }

}