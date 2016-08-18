using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Usa.Vehicles
{
	public class Liberty : HeavyVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<Liberty>("uv_liberty");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}