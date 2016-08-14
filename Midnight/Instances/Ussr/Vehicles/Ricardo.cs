using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Ricardo : HeavyVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Ricardo>("sv_ricardo");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}