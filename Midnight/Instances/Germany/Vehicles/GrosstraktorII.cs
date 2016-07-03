using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Vehicle
{
	public class GrosstraktorII : MediumVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<GrosstraktorII>("gv_grosstraktorII");


		public override Proto GetProto ()
		{
			return proto;
		}
	}
}