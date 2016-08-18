using Midnight.ActionManager.Events;
using Midnight.Cards.Types;
using Midnight.Emitter;
using Midnight.Actions;

namespace Midnight.Abilities.Passive
{
	public class Supply : CardAbility<ForefrontCard>, IListener<Before<Deployed>>
	{
		public void On (Before<Deployed> ev)
		{
			if (IsActive() && ev.Action.Card == Card)
            {
				ev.Action.AddChild(new DrawRandom(Chief));
			}
		}
	}
}
