using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Cards.Props;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class DealDamage : GameAction<DealDamage>
	{

		public class NonLethal : DealDamage
		{
			public NonLethal (int value, Card source, ForefrontCard target) : base(value, source, target)
			{
			}

			public override void Configure ()
			{
				modifier
					.SetValue(GetFinalDamage())
					.SetTarget(target)
					.SetSource(source);

				AddChild(new AddModifier(modifier));
			}
		} 

		public readonly Modifier modifier;
		public readonly Card source;
		public readonly ForefrontCard target;
		public int value { get; private set; }

		public DealDamage (int value, Card source, ForefrontCard target)
		{
			this.value = value;
			this.source = source;
			this.target = target;

			modifier = new Modifier(Property.damage);
		}

		public int GetFinalDamage ()
		{
			return Card.Limit(value, target.GetLives());
		}

		public int GetDamage ()
		{
			return Card.Limit(value);
		}

		public void ModifyDamage (int diff)
		{
			value += diff;
			modifier.SetValue(GetFinalDamage());
		}

		public override void Configure ()
		{
			modifier
				.SetValue(GetFinalDamage())
				.SetTarget(target)
				.SetSource(source);

			AddChild(new AddModifier(modifier));
			AddChild(new Death(target));
		}

		public override Status Validation ()
		{
			if (target == null) {
				return Status.NoCard;
			}

			if (!target.GetLocation().IsForefront()) {
				return Status.NotAtForefront;
			}

			return Status.Success;
		}
	}
}
