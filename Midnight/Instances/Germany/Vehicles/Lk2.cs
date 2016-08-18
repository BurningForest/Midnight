using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Germany.Vehicles
{
	public class Lk2 : LightVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<Lk2>("gv_lk2");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}