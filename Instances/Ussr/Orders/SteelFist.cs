using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Instances.Ussr.Orders
{
	public class SteelFist : Order
	{
		// Нанесите 5 повреждений штабу противника.

		public static readonly Proto proto = new Proto() {
			id = "so_udarmolota",
			level = 1,
			type = Type.order,
			subtype = Subtype.order,
			country = Country.ussr,

			cost = 9,
		};

		public class SteelFistAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new[] { new DealDamage(5, card, target) };
			}

			protected override Search Targets (Search search)
			{
				return search
					.Enemy().Forefront()
					.Hq();
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new SteelFistAbility());
		}
	}
}
