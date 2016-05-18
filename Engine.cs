using System;
using Midnight.Actions;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Triggers;

namespace Midnight
{
	public class Engine
	{

		public class ClonedEngine : Engine {
		}

		public static void Main (string[] args) {}

		public readonly Emitter.EventEmitter emitter;
		public readonly ActionManager.Manager actions;
		public readonly Battlefield.Field field;
		public readonly Chief[] chiefs;
		public readonly Turn turn;
		public readonly Lantern lantern;
		public readonly Cache cache;
		public readonly TriggersContainer triggers;

		public Final final { get; private set; }

		public Engine ()
		{
			emitter = new Emitter.EventEmitter();
			actions = new ActionManager.Manager(this);

			cache = new Cache();
			triggers = new TriggersContainer(this);

			field = new Battlefield.Field().SetSize(5, 3);

			chiefs = new Chief[]{
				new Chief(0).SetEngine(this),
				new Chief(1).SetEngine(this),
			};

			turn = new Turn(this);
			lantern = new Lantern(this);
		}

		public ClonedEngine Clone ()
		{
			return new Copier(this).GetClone();
		}

		internal void Finish (Final final)
		{
			if (this.final == null) {
				this.final = final;
			}
		}

	}
}
