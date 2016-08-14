using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class T24 : HeavyVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<T24>("sv_t24");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}