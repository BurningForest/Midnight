using System;
using Midnight.ActionManager;
using Midnight.Cards.Types;
using Midnight.Abilities.Passive;
using static Midnight.Cards.Types.Platoon;

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


			if (source.abilities.Has<PlatoonEnforced>()) {
				PlatoonsEnforce();
			}
			if (source.abilities.Has<PlatoonProtected>()) {
				PlatoonsProtect();
			}

			AddChild(damage);
			return damage;
		}

		private void PlatoonsEnforce ()
		{
			foreach (var platoon in source.GetChief().cards.GetOrderedPlatoons()) {
				if (platoon is Enforce) {
					damage.ModifyDamage(platoon.GetPower());
					AddChild(new ActivatePlatoon(platoon, platoon.GetPower()));
				}
			}
		}

		private void PlatoonsProtect ()
		{
			foreach (var platoon in target.GetChief().cards.GetOrderedPlatoons()) {
				if (platoon is Protect && damage.GetDamage() > 0) {
					var value = Math.Min(damage.GetDamage(), platoon.GetDefense());

					damage.ModifyDamage(-value);
					AddChild(new ActivatePlatoon(platoon, value));
				}
			}
		}
	}
}
