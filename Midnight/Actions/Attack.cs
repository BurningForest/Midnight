using AttackAbility = Midnight.Abilities.Aggression.Attack;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class Attack : FightAction<Attack>
	{
		public Attack (FieldCard source, FieldCard target)
			: base(source, target)
		{
		}

		public override void Configure ()
		{
			CreateDamageAction();
		}

		public override Status Validation ()
		{
			return Source.abilities.Get<AttackAbility>().ValidateTarget(Target);
		}
	}
}
