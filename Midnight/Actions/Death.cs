﻿using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Death : GameAction<Death>
	{
		public class Forced : Death
		{
			public Forced (Card card) : base(card) {}

			public override Status Validation ()
			{
				return Status.Success;
			}
		}

		public readonly Card card;

		public Death (Card card)
		{
			this.card = card;
		}

		public override void Configure ()
		{
			card.GetLocation().ToGraveyard();

			GetEngine().lantern.RecountTo(this);
		}

		public override Status Validation ()
		{
			if (card.GetLives() > 0) {
				return Status.CardHasLives;
			}

			return Status.Success;
		}
	}
}