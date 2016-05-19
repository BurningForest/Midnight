﻿using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Tests.TestInstances
{
	public class TankMedium : MediumVehicle
	{
		public static readonly Proto proto = new Proto<TankMedium>() {
			id = "tv_medium_tank",
			level = 1,
			type = Type.vehicle,
			subtype = Subtype.medium,
			country = Country.germany,

			power = 2,
			defense = 0,
			toughness = 5,
			increase = 1,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}