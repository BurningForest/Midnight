using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class Schlepper25PS : SpatgVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Schlepper25PS>("gv_schlepper_25ps");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}