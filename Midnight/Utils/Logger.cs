using Midnight.ActionManager;
using Midnight.ActionManager.Events;
using Midnight.Emitter;
using System;
using System.Collections.Generic;

namespace Midnight.Utils
{
    public class Logger :
        IListener<Before<GameAction>>,
        IListener<Failure<GameAction>>
    {
        private readonly List<GameAction> _actions = new List<GameAction>();
        private readonly List<GameAction> _failures = new List<GameAction>();
        private readonly ActionsStringifier _stringifier = new ActionsStringifier();

        public Logger(Engine engine)
        {
            engine.Emitter.Subscribe(this);
        }

        public void On(Before<GameAction> e)
        {
            if (e.Action.IsTop())
            {
                _actions.Add(e.Action);
            }

            Log(e.Action);
        }

        private void Log(GameAction action)
        {
            Console.Write(GetPrefix(action));
            Console.Write(_stringifier.GetName(action));
            Console.Write("(" + string.Join(", ", _stringifier.GetArgs(action)) + ")");

            if (!action.IsValid())
            {
                Console.Write(":" + action.GetStatus());
            }

            Console.WriteLine();
        }

        private string GetPrefix(GameAction action)
        {
            return Repeat("| ", CountDepth(action)); ;
        }

        private string Repeat(string str, int count)
        {
            var result = "";

            while (count-- > 0) result += str;

            return result;
        }

        private int CountDepth(GameAction action)
        {
            int num = 0;

            while (!action.IsTop())
            {
                ++num;
                action = action.GetParent();
            }

            return num;
        }

        public void On(Failure<GameAction> e)
        {
            _failures.Add(e.Action);
            Log(e.Action);
        }
    }
}
