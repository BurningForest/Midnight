using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Germany.Vehicles
{
	public class A7V : HeavyVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<A7V>("gv_a7v");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}