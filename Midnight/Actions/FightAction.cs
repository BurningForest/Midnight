using System;
using System.Linq;
using Midnight.ActionManager;
using Midnight.Cards.Types;
using Midnight.Abilities.Passive;
using static Midnight.Cards.Types.Platoon;

namespace Midnight.Actions
{
	public abstract class FightAction<TAction> : GameAction<TAction>
		where TAction : FightAction<TAction>
	{
		public readonly FieldCard Source;
		public readonly FieldCard Target;
		public DealDamage Damage { get; protected set; }

	    public FightAction (FieldCard source, FieldCard target)
		{
			Source = source;
			Target = target;
		}

		protected DealDamage CreateDamageAction ()
		{
			Damage = new DealDamage.NonLethal(Source.GetPower(), Source, Target);

			if (Source.Abilities.Has<PlatoonEnforced>())
            {
				PlatoonsEnforce();
			}

			if (Target.Abilities.Has<PlatoonProtected>())
            {
				PlatoonsProtect();
			}

			AddChild(Damage);
			return Damage;
		}

		private void PlatoonsEnforce ()
		{
		    foreach (var platoon in Source.GetChief().Cards.GetOrderedPlatoons().OfType<Enforce>())
		    {
		        Damage.ModifyDamage(platoon.GetPower());
		        AddChild(new ActivatePlatoon(platoon, platoon.GetPower()));
		    }
		}

	    private void PlatoonsProtect ()
		{
			foreach (var platoon in Target.GetChief().Cards.GetOrderedPlatoons())
			{
			    var protect = platoon as Protect;
			    if (protect != null && Damage.GetDamage() > 0)
                {
					var value = Math.Min(Damage.GetDamage(), protect.GetDefense());

					Damage.ModifyDamage(-value);
					AddChild(new ActivatePlatoon(platoon, value));
				}
			}
		}
	}
}
