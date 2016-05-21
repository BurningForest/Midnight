﻿using Midnight.Abilities.Passive;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;

namespace Midnight.Instances.Germany.Vehicle
{
	public class StPz2 : SpgVehicle
	{

		public static readonly Proto proto = new Proto<StPz2>() {
			id = "gv_sturmpanzerII",
			level = 5,
			type = Type.vehicle,
			subtype = Subtype.spatg,
			country = Country.germany,

			power = 2,
			defense = 0,
			toughness = 4,
			increase = 0,
			cost = 4,
		};
		
		public class GermanySupply : Supply
		{
			public override bool IsActive ()
			{
				return chief.cards.HasHq(Country.germany);
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new GermanySupply());
		}
	}
}