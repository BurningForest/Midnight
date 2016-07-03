using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class LkII : LightVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<LkII>("gv_lkII");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}