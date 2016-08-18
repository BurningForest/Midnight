using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class T24 : HeavyVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<T24>("sv_t24");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}