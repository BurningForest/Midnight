using System;
using Midnight.ActionManager;
using Midnight.Cards.Types;

namespace Midnight.Actions
{
	public abstract class FightAction<TAction> : GameAction<TAction>
		where TAction : FightAction<TAction>
	{
		public readonly FieldCard source;
		public readonly FieldCard target;
		public DealDamage damage { get; protected set; }

		public FightAction (FieldCard source, FieldCard target)
		{
			this.source = source;
			this.target = target;
		}

		protected DealDamage CreateDamageAction ()
		{
			damage = new DealDamage(source.GetPower(), source, target);

			AddChild(damage);

			// todo: add platoon influence

			return damage;
		}
	}
}
