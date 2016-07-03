using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Hqs
{
	public class TrainingCamp : Hq
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<TrainingCamp>("uh_fort_bragg");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}