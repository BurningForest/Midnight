using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicles
{
	public class Grosstraktor2 : MediumVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Grosstraktor2>("gv_grosstraktor2");


		public override Proto GetProto ()
		{
			return proto;
		}
	}
}