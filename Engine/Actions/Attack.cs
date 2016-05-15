using AttackAbility = Midnight.Engine.Abilities.Aggression.Attack;
using Midnight.Engine.ActionManager;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Actions
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
			return source.abilities.Get<AttackAbility>().ValidateTarget(target);
		}
	}
}
