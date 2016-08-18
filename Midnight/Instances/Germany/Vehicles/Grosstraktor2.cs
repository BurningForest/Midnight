using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Germany.Vehicles
{
	public class Grosstraktor2 : MediumVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<Grosstraktor2>("gv_grosstraktor2");


		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}