﻿using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Ms1 : LightVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Ms1>("sv_ms1");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}