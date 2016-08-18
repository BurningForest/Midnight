using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Cards.Props;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class DealDamage : GameAction<DealDamage>
	{
        public readonly Modifier Modifier;
        public readonly Card Source;
        public readonly ForefrontCard Target;
        public int Value { get; private set; }
        public class NonLethal : DealDamage
		{
			public NonLethal (int value, Card source, ForefrontCard target) : base(value, source, target)
			{
			}

			public override void Configure ()
			{
				Modifier
					.SetValue(GetFinalDamage())
					.SetTarget(Target)
					.SetSource(Source);

				AddChild(new AddModifier(Modifier));
			}
		} 
		public DealDamage (int value, Card source, ForefrontCard target)
		{
			Value = value;
			Source = source;
			Target = target;

			Modifier = new Modifier(Property.damage);
		}

		public int GetFinalDamage ()
		{
			return Card.Limit(Value, Target.GetLives());
		}

		public int GetDamage ()
		{
			return Card.Limit(Value);
		}

		public void ModifyDamage (int diff)
		{
			Value += diff;
			Modifier.SetValue(GetFinalDamage());
		}

		public override void Configure ()
		{
			Modifier
				.SetValue(GetFinalDamage())
				.SetTarget(Target)
				.SetSource(Source);

			AddChild(new AddModifier(Modifier));
			AddChild(new Death(Target));
		}

		public override Status Validation ()
		{
			if (Target == null)
            {
				return Status.NoCard;
			}

			return !Target.GetLocation().IsForefront() ? Status.NotAtForefront : Status.Success;
		}
	}
}
