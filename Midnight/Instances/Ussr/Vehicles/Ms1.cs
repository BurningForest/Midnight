using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Ussr.Vehicles
{
	public class Ms1 : LightVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<Ms1>("sv_ms1");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}