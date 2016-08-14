using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class Liberty : HeavyVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Liberty>("uv_liberty");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}