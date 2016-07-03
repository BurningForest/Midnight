using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class M1919 : LightVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<M1919>("uv_m1919");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}