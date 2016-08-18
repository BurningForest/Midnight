using System;
using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.ChiefOperations
{
    public class Turn : IListener<After<EndTurn>>
    {
        private readonly Engine _engine;
        private int _number;
        private Chief _owner;

        public Turn(Engine engine)
        {
            _engine = engine;

            engine.Emitter.Subscribe(this);
        }

        public int GetNumber()
        {
            return _number;
        }

        public void StartWith(Chief chief)
        {
            if (_owner != null)
            {
                throw new Exception("Already started");
            }

            _owner = chief;
        }

        public void StartWith(Chief chief, int number)
        {
            _number = number;
            StartWith(chief);
        }

        private void ChangeOwner()
        {
            _owner = _owner.GetOpponent();
            ++_number;
        }

        public Chief GetOwner()
        {
            return _owner;
        }

        public void On(After<EndTurn> ev)
        {
            ChangeOwner();
            _engine.Actions.Delay(new BeginTurn(GetOwner(), ev.Action));
        }
    }
}
