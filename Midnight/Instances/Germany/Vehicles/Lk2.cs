using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicles
{
	public class Lk2 : LightVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Lk2>("gv_lk2");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}