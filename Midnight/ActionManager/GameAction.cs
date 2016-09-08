using Midnight.ActionManager.Events;
using Midnight.Core;
using Midnight.Emitter;
using System;
using System.Collections.Generic;

namespace Midnight.ActionManager
{
	public abstract class GameAction
	{
		private Status _status = Status.Idle;
		private readonly List<GameAction> _children = new List<GameAction>();
		private bool _isClosed;
		private GameAction _parent;

		private Manager _manager;
		private Engine _engine;

		protected Engine GetEngine ()
		{
			return _engine;
		}

		internal abstract void NotifyBefore (EventEmitter emitter);
		internal abstract void NotifyInside (EventEmitter emitter);
		internal abstract void NotifyAfter (EventEmitter emitter);
		internal abstract void NotifyFailure (EventEmitter emitter);
		internal abstract void NotifyFinish (EventEmitter emitter);

		public Status GetStatus ()
		{
			return _status;
		}

		public List<GameAction> Children
		{
            get
            {
                return _children;
            }
		}

		public GameAction AddChild (GameAction action)
		{
			if (_isClosed)
            {
				throw new Exception("Cannot add child action to closed action");
			}

			_children.Add(action);
			action.SetParent(this);
			_manager.Register(action);
			return this;
		}

		private void SetParent (GameAction action)
		{
			if (_parent != null)
            {
				throw new Exception("Parent is already set");
			}

			_parent = action;
		}

		public GameAction GetParent ()
		{
			return _parent;
		}

		public bool IsTop ()
		{
			return _parent == null;
		}

		public GameAction GetTop ()
		{
			return IsTop() ? this : _parent.GetTop();
		}

		public bool HasAncestor<TAction> ()
			where TAction : GameAction
		{
			var action = this;

			while (action.IsTop() == false)
            {
				action = action.GetParent();
				if (action is TAction)
                {
					return true;
				}
			}

			return false;
		}

		public GameAction AddChildren (IEnumerable<GameAction> actions)
		{
			foreach (var action in actions)
            {
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
			_manager = manager;
		}

		internal void SetEngine (Engine engine)
		{
			_engine = engine;
		}

		internal bool IsValid ()
		{
			return _status == Status.Success;
		}

		internal void Validate ()
		{
			_status = Validation();
		}

		internal void Close ()
		{
			_isClosed = true;
		}

	}

	public abstract class GameAction<TAction> : GameAction
		where TAction : GameAction<TAction>
	{

		internal override void NotifyBefore (EventEmitter emitter)
		{
			emitter.Publish(new Before<TAction>((TAction)this));
			emitter.Publish(new Before<GameAction>(this));
		}

		internal override void NotifyInside (EventEmitter emitter)
		{
			emitter.Publish(new Inside<TAction>((TAction)this));
			emitter.Publish(new Inside<GameAction>(this));
		}

		internal override void NotifyAfter (EventEmitter emitter)
		{
			emitter.Publish(new After<TAction>((TAction)this));
			emitter.Publish(new After<GameAction>(this));
		}

		internal override void NotifyFailure (EventEmitter emitter)
		{
			emitter.Publish(new Failure<TAction>((TAction)this));
			emitter.Publish(new Failure<GameAction>(this));
		}

		internal override void NotifyFinish (EventEmitter emitter)
		{
			emitter.Publish(new Finish<TAction>((TAction)this));
			emitter.Publish(new Finish<GameAction>(this));
		}
	}

}
