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
			if (IsActive() && ev.action.card == Card)
            {
				ev.action.AddChild(new DrawRandom(Chief));
			}
		}
	}
}
