using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class M2A1_AT : SpatgVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<M2A1_AT>("uv_m2a1_at");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}