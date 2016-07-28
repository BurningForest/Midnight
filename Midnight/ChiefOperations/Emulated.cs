using Midnight.ActionManager;
using Midnight.ActionManager.Events;
using Midnight.Core;
using Midnight.Emitter;
using System.Collections.Generic;
using System;
using Midnight.Cards.Props;
using Midnight.Actions;
using System.Linq;

namespace Midnight.ChiefOperations
{
	public class Emulated : IIo, IListener<Before<GameAction>>
	{
		public class Prediction
		{
			public int cardId;
			public Property property;
			public int value;
		}

		private readonly Engine engine;
		private readonly int chiefIndex;
		
		private List<GameAction> actions = new List<GameAction>();

		public Emulated (Chief chief)
		{
			chiefIndex = chief.index;
			engine = chief.GetEngine().Clone();
			engine.emitter.Subscribe(this);
		}

		public void On (Before<GameAction> ev)
		{
			if (ev.action.IsTop()) {
				actions.Add(ev.action);
			}
		}

		public List<GameAction> GetActions ()
		{
			return actions;
		}

		public Chief GetChief ()
		{
			return engine.chiefs[chiefIndex];
		}

		public Status Attack (Io.Target command)
		{
			return GetChief().io.Attack(command);
		}

		public Status Deploy (Io.SingleCard command)
		{
			return GetChief().io.Deploy(command);
		}

		public Status Deploy (Io.Position command)
		{
			return GetChief().io.Deploy(command);
		}

		public Status Move (Io.Position command)
		{
			return GetChief().io.Move(command);
		}

		public Status Order (Io.Target command)
		{
			return GetChief().io.Order(command);
		}

		public Status Order (Io.SingleCard command)
		{
			return GetChief().io.Order(command);
		}

		public Status EndTurn ()
		{
			return GetChief().io.EndTurn();
		}

		public List<Prediction> GetDamagePredictions ()
		{
			return GetPropertyPredictions(Property.damage);
		}

		public List<Prediction> GetPropertyPredictions (Property property)
		{
			var predictions = new Dictionary<int, Prediction>();
			var list = new List<Prediction>();

			foreach (var modifier in CollectModifiers()) {
				if (property == modifier.GetProperty()) {
					int target = modifier.GetTarget().id;

					if (predictions.ContainsKey(target)) {
						predictions[target].value += modifier.GetValue();
					} else {
						var item = new Prediction() {
							value = modifier.GetValue(),
							cardId = target,
							property = property
						};

						list.Add(item);
						predictions.Add(target, item);
					}
				}
			}

			return list;
		}

		public List<Modifier> CollectModifiers ()
		{
			return CollectModifiersFrom(actions);
		}

		private List<Modifier> CollectModifiersFrom (List<GameAction> actions)
		{
			var list = new List<Modifier>();

			foreach (var action in actions) {
				if (action is AddModifier) {
					list.Add(((AddModifier)action).modifier);
				}

				list.AddRange(CollectModifiersFrom(action.Children));
			}

			return list;
		}
	}
}
