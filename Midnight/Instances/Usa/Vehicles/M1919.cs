using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Usa.Vehicles
{
	public class M1919 : LightVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<M1919>("uv_m1919");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}