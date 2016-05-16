using Midnight.ActionManager.Events;
using Midnight.Core;
using Midnight.Emitter;
using System;
using System.Collections.Generic;

namespace Midnight.ActionManager
{
	public abstract class GameAction
	{
		private Status status = Status.Idle;
		private List<GameAction> children = new List<GameAction>();
		private bool isClosed = false;
		private GameAction parent = null;

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

		internal abstract void NotifyBefore (EventEmitter emitter);
		internal abstract void NotifyInside (EventEmitter emitter);
		internal abstract void NotifyAfter (EventEmitter emitter);
		internal abstract void NotifyFailure (EventEmitter emitter);
		internal abstract void NotifyFinish (EventEmitter emitter);

		public Status GetStatus ()
		{
			return status;
		}

		public List<GameAction> GetChildren ()
		{
			return children;
		}

		public GameAction AddChild (GameAction action)
		{
			if (isClosed) {
				throw new Exception("Cannot add child action to closed action");
			}

			children.Add(action);
			action.SetParent(this);
			manager.Register(action);
			return this;
		}

		private void SetParent (GameAction action)
		{
			if (parent != null) {
				throw new Exception("Parent is already set");
			}

			parent = action;
		}

		public GameAction GetParent ()
		{
			return parent;
		}

		public bool IsTop ()
		{
			return parent == null;
		}

		public GameAction GetTop ()
		{
			return IsTop() ? this : parent.GetTop();
		}

		public bool HasAncestor<TAction> ()
			where TAction : GameAction
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

		public GameAction AddChildren (IEnumerable<GameAction> actions)
		{
			foreach (GameAction action in actions) {
				AddChild(action);
			}
			return this;
		}


		public virtual void Complete () { }
		public virtual void Configure () { }
		public virtual Status Validation ()
		{
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

	public abstract class GameAction<TAction> : GameAction
		where TAction : GameAction<TAction>
	{

		internal override void NotifyBefore (EventEmitter emitter)
		{
			emitter.Publish(new Before<TAction>(this as TAction));
			emitter.Publish(new Before<GameAction>(this));
		}

		internal override void NotifyInside (EventEmitter emitter)
		{
			emitter.Publish(new Inside<TAction>(this as TAction));
			emitter.Publish(new Inside<GameAction>(this));
		}

		internal override void NotifyAfter (EventEmitter emitter)
		{
			emitter.Publish(new After<TAction>(this as TAction));
			emitter.Publish(new After<GameAction>(this));
		}

		internal override void NotifyFailure (EventEmitter emitter)
		{
			emitter.Publish(new Failure<TAction>(this as TAction));
			emitter.Publish(new Failure<GameAction>(this));
		}

		internal override void NotifyFinish (EventEmitter emitter)
		{
			emitter.Publish(new Finish<TAction>(this as TAction));
			emitter.Publish(new Finish<GameAction>(this));
		}
	}

}
