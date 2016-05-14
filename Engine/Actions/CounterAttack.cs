﻿using CounterAttackAbility = Midnight.Engine.Abilities.Aggression.CounterAttack;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Actions
{
	public class CounterAttack : FightAction<CounterAttack>
	{
		public CounterAttack (FieldCard source, FieldCard target)
			: base(source, target)
		{
		}

		public override void Configure ()
		{
			source.abilities.Get<CounterAttackAbility>().Activate();
			CreateDamageAction();
		}

		public override Status Validation ()
		{
			if (!source.abilities.Has<CounterAttackAbility>()) {
				return Status.NoCounterAttackAbility;
			}

			return source.abilities.Get<CounterAttackAbility>().Validate(target);
		}
	}
}