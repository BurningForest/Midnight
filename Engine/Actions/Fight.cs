using System;
using Midnight.Engine.ActionManager;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;
using AttackAbility = Midnight.Engine.Abilities.Aggression.Attack;

namespace Midnight.Engine.Actions
{
	public class Fight : GameAction<Fight>
	{
		public readonly FieldCard source;
		public readonly FieldCard target;
		private FightRound[] rounds = new FightRound[2];

		public Fight (FieldCard source, FieldCard target)
		{
			this.source = source;
			this.target = target;
		}

		public override void Configure ()
		{
			source.abilities.Get<AttackAbility>().Activate();

			rounds[0] = new FightRound();
			rounds[1] = new FightRound();

			GetRoundFor(source).AddFightAction(new Attack(source, target));

			if (!CanPreventCounter(source)) {
				GetRoundFor(target).AddFightAction(new CounterAttack(target, source));
			}

			AddChildren(rounds);
		}

		private FightRound GetRoundFor (FieldCard card)
		{
			return rounds[HasFirstStrike(card) ? 0 : 1]; // todo : add FirstStrike
		}

		private bool HasFirstStrike (FieldCard card)
		{
			return false;
		}

		private bool CanPreventCounter (FieldCard source)
		{
			return false;
		}

		public override Status Validation ()
		{
			if (!source.abilities.Has<AttackAbility>()) {
				return Status.NoAttackAbility;
			}

			return source.abilities.Get<AttackAbility>().Validate();
		}
	}
}
