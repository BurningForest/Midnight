using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.Instances.Usa.Hqs
{
	public class TrainingCamp : Hq
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<TrainingCamp>("uh_fort_bragg");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}