using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Ricardo : HeavyVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<Ricardo>("sv_ricardo");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}