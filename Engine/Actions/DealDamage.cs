using Midnight.Engine.ActionManager;
using Midnight.Engine.Cards;
using Midnight.Engine.Cards.Props;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Core;

namespace Midnight.Engine.Actions
{
	public class DealDamage : GameAction<DealDamage>
	{

		public class NonLethal : DealDamage
		{
			public NonLethal (int value, FieldCard source, FieldCard target) : base(value, source, target)
			{
			}

			public override void Configure ()
			{
				AddChild(new AddModifier(modifier));
				AddChild(new Death(target));
			}
		} 

		private readonly Modifier modifier;
		private FieldCard source;
		private FieldCard target;
		private int value;

		public DealDamage (int value, FieldCard source, FieldCard target)
		{
			this.value = value;
			this.source = source;
			this.target = target;

			modifier = new Modifier(Property.damage)
				.SetValue(GetFinalDamage())
				.SetTarget(target)
				.SetSource(source);
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
			AddChild(new AddModifier(modifier));
			AddChild(new Death(target));
		}

		public override Status Validation ()
		{
			if (!target.GetFieldLocation().IsForefront()) {
				return Status.NotAtForefront;
			}

			return Status.Success;
		}
	}
}
