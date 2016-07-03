using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class M1921 : MediumVehicle
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<M1921>("uv_m1921");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}