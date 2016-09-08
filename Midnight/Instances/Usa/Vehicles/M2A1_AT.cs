using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Usa.Vehicles
{
	public class M2A1_AT : SpatgVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<M2A1_AT>("uv_m2a1_at");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}