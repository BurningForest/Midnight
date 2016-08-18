using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Cards.Props;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class HealDamage : GameAction<HealDamage>
	{

		public readonly Modifier Modifier;
		public readonly Card Source;
		public readonly ForefrontCard Target;
		public int Value { get; private set; }

		public HealDamage (int value, Card source, ForefrontCard target)
		{
			Value = value;
			Source = source;
			Target = target;

			Modifier = new Modifier(Property.damage);
		}

		public int GetFinalHeal ()
		{
			return -Card.Limit(Value, Target.GetDamage());
		}

		public int GetHeal ()
		{
			return Card.Limit(Value);
		}

		public void ModifyDamage (int diff)
		{
			Value += diff;
			Modifier.SetValue(GetFinalHeal());
		}

		public override void Configure ()
		{
			Modifier
				.SetValue(GetFinalHeal())
				.SetTarget(Target)
				.SetSource(Source);

			AddChild(new AddModifier(Modifier));
		}

		public override Status Validation ()
		{
			if (Target == null)
            {
				return Status.NoCard;
			}

			if (!Target.GetLocation().IsForefront())
            {
				return Status.NotAtForefront;
			}

			return Target.GetDamage() == 0 ? Status.TargetIsNotDamaged : Status.Success;
		}
	}
}
