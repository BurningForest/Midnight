using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class GiveOrder : GameAction<GiveOrder>
	{
		public readonly Order source;
		public readonly FieldCard target;

		public GiveOrder (Order source, FieldCard target)
		{
			this.source = source;
			this.target = target;
		}

		public GiveOrder (Order source)
		{
			this.source = source;
		}
		
		public override void Configure ()
		{
			AddChild(PayResources.ForCard(source));
			AddChildren(source.abilities.Get<Ordering>().Activate(target));
			AddChild(new Death.Forced(source));
		}

		public override Status Validation ()
		{
			var ability = source.abilities.Get<Ordering>();

			if (ability == null) {
				return Status.NoOrderingAbility;
			}

			return ability.Validate(target);
		}
	}
}
