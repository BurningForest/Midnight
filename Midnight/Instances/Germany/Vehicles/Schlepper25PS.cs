using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Germany.Vehicles
{
	public class Schlepper25PS : SpatgVehicle
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<Schlepper25PS>("gv_s25ps");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}