using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Tests.Fight;
using System;

namespace Midnight
{
	public class Engine
	{

		public static void Main (string[] args) {}

		public readonly Emitter.EventEmitter emitter;
		public readonly ActionManager.Manager actions;
		public readonly Battlefield.Field field;
		public readonly Chief[] chiefs;
		public readonly Turn turn;
		public readonly Lantern lantern;

		public Engine ()
		{
			emitter = new Emitter.EventEmitter();
			actions = new ActionManager.Manager(this);

			field = new Battlefield.Field().SetSize(5, 3);

			chiefs = new Chief[]{
				new Chief(0).SetEngine(this),
				new Chief(1).SetEngine(this),
			};

			turn = new Turn(this);
			lantern = new Lantern(this);
		}

	}
}
