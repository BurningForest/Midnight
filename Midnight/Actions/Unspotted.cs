﻿using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public class Unspotted : GameAction<Unspotted>
	{
		public readonly FieldCard card;

		public Unspotted (FieldCard card)
		{
			this.card = card;
		}
	}
}