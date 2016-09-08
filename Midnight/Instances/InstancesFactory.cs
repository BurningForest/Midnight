using System.Collections.Generic;
using Sun.CardProtos;
using Midnight.Instances.Germany.Hqs;
using Midnight.Instances.Germany.Vehicles;
using Midnight.Instances.Germany.Orders;

using Midnight.Instances.Usa.Hqs;
using Midnight.Instances.Usa.Vehicles;
using Midnight.Instances.Usa.Orders;

using Midnight.Instances.Ussr.Hqs;
using Midnight.Instances.Ussr.Vehicles;
using Midnight.Instances.Ussr.Orders;

namespace Midnight.Instances
{
    public class InstancesFactory
    {
        private readonly Dictionary<string, Proto> _protosMap = new Dictionary<string, Proto>()
        {
            //Germany
            { Training.Proto.ID, Training.Proto },
            { ParisGun.Proto.ID, ParisGun.Proto },
            { A7V.Proto.ID, A7V.Proto },
            { Grosstraktor2.Proto.ID, Grosstraktor2.Proto },
            { Lk2.Proto.ID, Lk2.Proto },
            { Schlepper25PS.Proto.ID, Schlepper25PS.Proto },
            //USA
            { TrainingCamp.Proto.ID, TrainingCamp.Proto },
            { FordT.Proto.ID, FordT.Proto },
            { Liberty.Proto.ID, Liberty.Proto },
            { M1919.Proto.ID, M1919.Proto },
            { M1921.Proto.ID, M1921.Proto },
            { M2A1_AT.Proto.ID, M2A1_AT.Proto },
            { T1Light.Proto.ID, T1Light.Proto },
            //USSR
            { TrainingBase.Proto.ID, TrainingBase.Proto },
            { IlyaMuromets.Proto.ID, IlyaMuromets.Proto },
            { Ms1.Proto.ID, Ms1.Proto },
            { Ricardo.Proto.ID, Ricardo.Proto },
            { Su1.Proto.ID, Su1.Proto },
            { T24.Proto.ID, T24.Proto }
        };

        private InstancesFactory()
        {
        }
        private sealed class FactorySingletonCreator
        {
            private static readonly InstancesFactory instance = new InstancesFactory();
            public static InstancesFactory Instance
            {
                get
                {
                    return instance;
                }
            }
        }

        public static InstancesFactory Instance
        {
            get
            {
                return FactorySingletonCreator.Instance;
            }
        }

        public Proto GetProto(string protoId)
        {
            Proto proto;
            var validId = _protosMap.TryGetValue(protoId, out proto);

            return validId ? proto : null;
        }
    }
}
