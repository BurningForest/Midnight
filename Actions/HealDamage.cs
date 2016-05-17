using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Cards.Props;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class HealDamage : GameAction<HealDamage>
	{

		public readonly Modifier modifier;
		public readonly Card source;
		public readonly ForefrontCard target;
		public int value { get; private set; }

		public HealDamage (int value, Card source, ForefrontCard target)
		{
			this.value = value;
			this.source = source;
			this.target = target;

			modifier = new Modifier(Property.damage);
		}

		public int GetFinalHeal ()
		{
			return -Card.Limit(value, target.GetDamage());
		}

		public int GetHeal ()
		{
			return Card.Limit(value);
		}

		public void ModifyDamage (int diff)
		{
			value += diff;
			modifier.SetValue(GetFinalHeal());
		}

		public override void Configure ()
		{
			modifier
				.SetValue(GetFinalHeal())
				.SetTarget(target)
				.SetSource(source);

			AddChild(new AddModifier(modifier));
		}

		public override Status Validation ()
		{
			if (target == null) {
				return Status.NoCard;
			}

			if (!target.GetLocation().IsForefront()) {
				return Status.NotAtForefront;
			}

			if (target.GetDamage() == 0) {
				return Status.TargetIsNotDamaged;
			}

			return Status.Success;
		}
	}
}
