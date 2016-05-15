﻿using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Core;

namespace Midnight.Engine
{
	public class Engine
	{
		public readonly Emitter.EventEmitter emitter;
		public readonly ActionManager.Manager actions;
		public readonly Battlefield.Field field;
		public readonly Chief[] chiefs;
		public readonly Turn turn;

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
		}

	}
}
