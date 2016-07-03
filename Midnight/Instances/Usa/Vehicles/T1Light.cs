using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T1Light : LightVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<T1Light>("uv_t1e1");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}