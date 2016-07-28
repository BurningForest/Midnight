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
        private Dictionary<string, Proto> protosMap = new Dictionary<string, Proto>()
        {
            //Germany
            { Training.proto.ID, Training.proto },
            { EachBattle.proto.ID, EachBattle.proto },
            { A7V.proto.ID, A7V.proto },
            { GrosstraktorII.proto.ID, GrosstraktorII.proto },
            { LkII.proto.ID, LkII.proto },
            { Schlepper25PS.proto.ID, Schlepper25PS.proto },
            //USA
            { TrainingCamp.proto.ID, TrainingCamp.proto },
            { HelpForTheFront.proto.ID, HelpForTheFront.proto },
            { Liberty.proto.ID, Liberty.proto },
            { M1919.proto.ID, M1919.proto },
            { M1921.proto.ID, M1921.proto },
            { M2A1_AT.proto.ID, M2A1_AT.proto },
            { T1Light.proto.ID, T1Light.proto },
            //USSR
            { TrainingBase.proto.ID, TrainingBase.proto },
            { HeartOfTheEnemy.proto.ID, HeartOfTheEnemy.proto },
            { Ms1.proto.ID, Ms1.proto },
            { RicardoTank.proto.ID, RicardoTank.proto },
            { Su1.proto.ID, Su1.proto },
            { T24.proto.ID, T24.proto }
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

        public Proto GetProto(string protoID)
        {
            Proto proto;
            bool validID = protosMap.TryGetValue(protoID, out proto);

            return validID ? proto : null;
        }
    }
}
