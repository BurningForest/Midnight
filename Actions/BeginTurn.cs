﻿using Midnight.ActionManager;
using Midnight.ChiefOperations;
using Midnight.Core;

namespace Midnight.Actions
{
	public class BeginTurn : GameAction<BeginTurn>
	{
		public readonly Chief chief;
		public readonly EndTurn turnEnd;

		public BeginTurn (Chief chief)
		{
			this.chief = chief;
			this.turnEnd = null;
		}

		public BeginTurn (Chief chief, EndTurn turnEnd)
		{
			this.chief = chief;
			this.turnEnd = turnEnd;
		}

		public bool IsInitial ()
		{
			return turnEnd == null;
		}

		public override void Configure ()
		{
			// todo turn
			// todo spotted
		}

		public override Status Validation ()
		{
			// todo isTurnOwner

			return Status.Success;
		}
	}
}