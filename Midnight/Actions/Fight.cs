using Midnight.ActionManager;
using Midnight.Cards.Types;
using Midnight.Core;
using Midnight.Abilities.Passive;
using Midnight.Abilities.Aggression;
using AttackAbility = Midnight.Abilities.Aggression.Attack;

namespace Midnight.Actions
{
	public class Fight : GameAction<Fight>
	{
		public readonly FieldCard Source;
		public readonly FieldCard Target;
		private readonly FightRound[] _rounds = new FightRound[2];

		public Fight (FieldCard source, FieldCard target)
		{
			Source = source;
			Target = target;
		}

		public override void Configure ()
		{
			Source.Abilities.Get<AttackAbility>().Activate();

			_rounds[0] = new FightRound();
			_rounds[1] = new FightRound();

			GetRoundFor(Source).AddFightAction(new Attack(Source, Target), Target);

			if (!CanPreventCounter(Source))
            {
				GetRoundFor(Target).AddFightAction(new CounterAttack(Target, Source), Source);
			}

			AddChildren(_rounds);
		}

		private FightRound GetRoundFor (FieldCard card)
		{
			return _rounds[HasFirstStrike(card) ? 0 : 1];
		}

		private bool HasFirstStrike (FieldCard card)
		{
			return card.Abilities.Has<FirstStrike>();
		}

		private bool CanPreventCounter (FieldCard source)
		{
			return source.Abilities.Has<WeaponArtillery>()
				|| source.Abilities.Has<Cover>();
		}

		public override Status Validation ()
		{
		    return !Source.Abilities.Has<AttackAbility>() ? Status.NoAttackAbility : Source.Abilities.Get<AttackAbility>().Validate(Target);
		}
	}
}
