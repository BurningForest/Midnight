﻿using Midnight.Engine.Abilities;

namespace Midnight.Engine.Cards
{
	public abstract class Order : Card
	{
        public override CardAbility[] CreateAbilities ()
        {
            return new CardAbility[] { };
        }
    }
}
