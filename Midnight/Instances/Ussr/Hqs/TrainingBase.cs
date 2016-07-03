using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Hqs
{
	public class TrainingBase : Hq
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<TrainingBase>("sh_orlovskoe_bu");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}