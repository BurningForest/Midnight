using Midnight.Cards.Vehicles;
using Sun.CardProtos;

namespace Midnight.Instances.Ussr.Vehicles
{
    public class Su1 : SpatgVehicle
    {
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Su1>("sv_su-1");

        public override Proto GetProto()
        {
            return proto;
        }
    }
}
