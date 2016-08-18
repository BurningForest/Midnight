using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Actions
{
	public class GiveOrder : GameAction<GiveOrder>
	{
		public readonly Order Source;
		public readonly FieldCard Target;

		public GiveOrder (Order source, FieldCard target)
		{
			Source = source;
			Target = target;
		}

		public GiveOrder (Order source)
		{
			Source = source;
		}
		
		public override void Configure ()
		{
			AddChild(PayResources.ForCard(Source));
			AddChildren(Source.abilities.Get<Ordering>().Activate(Target));
			AddChild(new Death.Forced(Source));
		}

		public override Status Validation ()
		{
			var ability = Source.abilities.Get<Ordering>();

			return ability?.Validate(Target) ?? Status.NoOrderingAbility;
		}
	}
}
