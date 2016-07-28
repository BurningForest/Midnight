using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicles
{
	public class A7V : HeavyVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<A7V>("gv_a7v");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}