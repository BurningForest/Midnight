﻿using Midnight.Abilities.Activating;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Cards;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Orders
{
	public class SteelFist : Order
	{
		// Нанесите 5 повреждений штабу противника.

		public static readonly Proto Proto = new ParameterizedProto<SteelFist>
		{
			ID = "so_udarmolota",
			Level = 1,
			Type = Type.Order,
			Country = Country.USSR,

			Cost = 9,
		};

		public class SteelFistAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new GameAction[] { new DealDamage(5, Card, target) };
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
			return Proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			Abilities.Add(new SteelFistAbility());
		}
	}
}
