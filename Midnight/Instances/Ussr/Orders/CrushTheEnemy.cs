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
	public class CrushTheEnemy : Order
	{
		// Нанесите 1 повреждение выбранному штабу или технике

		public static readonly Proto proto = new ParameterizedProto<CrushTheEnemy>() {
			ID = "so_takbilotakbudet",
			Level = 1,
			Type = Type.Order,
			Country = Country.USSR,

			Cost = 0,
		};

		public class CrushTheEnemyAbility : SpecificAbility
		{
			protected override GameAction[] Actions (ForefrontCard target)
			{
				return new[] { new DealDamage(1, card, target) };
			}

			protected override Search Targets (Search search)
			{
				return search
					.Enemy().Forefront()
					.Vehicle().Hq();
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new CrushTheEnemyAbility());
		}
	}
}
