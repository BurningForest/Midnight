using Midnight.Engine.Core;
using System;
using System.Collections.Generic;

namespace Midnight.Engine.ActionManager
{
	public abstract class Action {
		private Status status = Status.Idle;
		private List<Action> children = new List<Action>();
		private bool isClosed = false;
		private Action parent = null;

		private Manager manager;
		private Engine engine;

		protected Manager GetManager ()
		{
			return manager;
		}

		protected Engine GetEngine ()
		{
			return engine;
		}

		public Status GetStatus ()
		{
			return status;
		}

		public List<Action> GetChildren ()
		{
			return children;
		}

		public Action AddChild (Action action)
		{
			if (isClosed) {
				throw new Exception("Cannot add child action to closed action");
			}

			children.Add(action);
			action.SetParent(this);
			manager.Register(action);
			return this;
		}

		private void SetParent (Action action)
		{
			if (parent != null) {
				throw new Exception("Parent is already set");
			}

			parent = action;
		}

		public Action GetParent ()
		{
			return parent;
		}

		public bool IsTop ()
		{
			return parent == null;
		}

		public Action GetTop ()
		{
			return IsTop() ? this : parent.GetTop();
		}

		public bool IsChildOf<TAction> ()
			where TAction : Action
		{
			var action = this;

			while (action.IsTop() == false) {
				action = action.GetParent();
				if (action is TAction) {
					return true;
				}
			}

			return false;
		}

		public Action AddChildren (IEnumerable<Action> actions)
		{
			foreach (Action action in actions) {
				AddChild(action);
			}
			return this;
		}


		public virtual void Complete () { }
		public virtual void Configure () { }
		public virtual Status Validation () {
			return Status.Success;
		}

		internal void SetActionManager (Manager manager)
		{
			this.manager = manager;
		}

		internal void SetEngine (Engine engine)
		{
			this.engine = engine;
		}

		internal bool IsValid ()
		{
			return status == Status.Success;
		}

		internal void Validate ()
		{
			status = Validation();
		}

		internal void Close ()
		{
			isClosed = true;
		}

	}
}
