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
			damage = new DealDamage.NonLethal(source.GetPower(), source, target);

			if (source.abilities.Has<PlatoonEnforced>()) {
				PlatoonsEnforce();
			}
			if (target.abilities.Has<PlatoonProtected>()) {
				PlatoonsProtect();
			}

			AddChild(damage);
			return damage;
		}

		private void PlatoonsEnforce ()
		{
			foreach (var Platoon in source.GetChief().cards.GetOrderedPlatoons()) {
				if (Platoon is Enforce) {
					damage.ModifyDamage(Platoon.GetPower());
					AddChild(new ActivatePlatoon(Platoon, Platoon.GetPower()));
				}
			}
		}

		private void PlatoonsProtect ()
		{
			foreach (var Platoon in target.GetChief().cards.GetOrderedPlatoons()) {
				if (Platoon is Protect && damage.GetDamage() > 0) {
					var value = Math.Min(damage.GetDamage(), Platoon.GetDefense());

					damage.ModifyDamage(-value);
					AddChild(new ActivatePlatoon(Platoon, value));
				}
			}
		}
	}
}
