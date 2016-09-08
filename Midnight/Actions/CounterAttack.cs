using CounterAttackAbility = Midnight.Abilities.Aggression.CounterAttack;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class CounterAttack : FightAction<CounterAttack>
	{
		public CounterAttack (FieldCard source, FieldCard target)
			: base(source, target)
		{
		}

		public override void Configure ()
		{
			Source.Abilities.Get<CounterAttackAbility>().Activate();
			CreateDamageAction();
		}

		public override Status Validation ()
		{
		    return !Source.Abilities.Has<CounterAttackAbility>() ? 
                Status.NoCounterAttackAbility : 
                Source.Abilities.Get<CounterAttackAbility>().Validate(Target);
		}
	}
}