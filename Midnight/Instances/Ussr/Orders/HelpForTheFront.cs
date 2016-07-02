﻿using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Orders
{
	public class HelpForTheFront : Order
	{
		// Возьмите карту.
		// Восстановите 2 прочности своему штабу.

		public static readonly Proto proto = new ParameterizedProto<HelpForTheFront>() {
			ID = "so_budbditelnym",
			Level = 1,
			Type = Type.Order,
			Country = Country.USSR,

			Cost = 2,
		};

		public class HelpForTheFrontAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new GameAction[] {
					new DrawRandom(chief),
					new HealDamage(2, card, chief.cards.GetHq())
				};
			}

			protected override Search Targets (Search search)
			{
				return null;
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new HelpForTheFrontAbility());
		}
	}
}
