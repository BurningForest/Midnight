﻿using Midnight.Engine.Cards;
using Midnight.Engine.Cards.Enums;
using Midnight.Engine.Cards.Vehicles;

namespace Midnight.Tests.Instances
{
	public class SpgTank : SpgVehicle
	{
		public static readonly Proto proto = new Proto() {
			id = "tv_spg_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.spg,
			country = Country.usa,

			power = 1,
			defense = 0,
			toughness = 3,
			increase = 0,
			cost = 0,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}