using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class RicardoTank : HeavyVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<RicardoTank>("sv_ricardo_tank");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}