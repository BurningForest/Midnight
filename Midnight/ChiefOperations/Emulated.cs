using Midnight.ActionManager;
using Midnight.ActionManager.Events;
using Midnight.Core;
using Midnight.Emitter;
using System.Collections.Generic;
using Midnight.Cards.Props;
using Midnight.Actions;

namespace Midnight.ChiefOperations
{
    public class Emulated : IIo, IListener<Before<GameAction>>
    {
        public class Prediction
        {
            public int CardId { get; set; }
            public Property Property { get; set; }
            public int Value { get; set; }
        }

        private readonly Engine _engine;
        private readonly int _chiefIndex;

        private readonly List<GameAction> _actions = new List<GameAction>();

        public Emulated(Chief chief)
        {
            _chiefIndex = chief.index;
            _engine = chief.GetEngine().Clone();
            _engine.emitter.Subscribe(this);
        }

        public void On(Before<GameAction> ev)
        {
            if (ev.action.IsTop())
            {
                _actions.Add(ev.action);
            }
        }

        public List<GameAction> GetActions()
        {
            return _actions;
        }

        public Chief GetChief()
        {
            return _engine.chiefs[_chiefIndex];
        }

        public Status Attack(Io.Target command)
        {
            return GetChief().io.Attack(command);
        }

        public Status Deploy(Io.SingleCard command)
        {
            return GetChief().io.Deploy(command);
        }

        public Status Deploy(Io.Position command)
        {
            return GetChief().io.Deploy(command);
        }

        public Status Move(Io.Position command)
        {
            return GetChief().io.Move(command);
        }

        public Status Order(Io.Target command)
        {
            return GetChief().io.Order(command);
        }

        public Status Order(Io.SingleCard command)
        {
            return GetChief().io.Order(command);
        }

        public Status EndTurn()
        {
            return GetChief().io.EndTurn();
        }

        public Status Surrender()
        {
            return GetChief().io.Surrender();
        }

        public List<Prediction> GetDamagePredictions()
        {
            return GetPropertyPredictions(Property.damage);
        }

        public List<Prediction> GetPropertyPredictions(Property property)
        {
            var predictions = new Dictionary<int, Prediction>();
            var list = new List<Prediction>();

            foreach (var modifier in CollectModifiers())
            {
                if (property != modifier.GetProperty()) continue;
                var target = modifier.GetTarget().id;

                if (predictions.ContainsKey(target))
                {
                    predictions[target].Value += modifier.GetValue();
                }
                else
                {
                    var item = new Prediction
                    {
                        Value = modifier.GetValue(),
                        CardId = target,
                        Property = property
                    };

                    list.Add(item);
                    predictions.Add(target, item);
                }
            }

            return list;
        }

        public List<Modifier> CollectModifiers()
        {
            return CollectModifiersFrom(_actions);
        }

        private static List<Modifier> CollectModifiersFrom(List<GameAction> actions)
        {
            var list = new List<Modifier>();

            foreach (var action in actions)
            {
                var modifier = action as AddModifier;
                if (modifier != null)
                {
                    list.Add(modifier.modifier);
                }

                list.AddRange(CollectModifiersFrom(action.Children));
            }

            return list;
        }

        public void Clear()
        {
            _actions.Clear();
        }
    }
}
