using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Usa.Vehicles
{
	public class T1Light : LightVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<T1Light>("uv_t1e1");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}