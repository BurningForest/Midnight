using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.Instances.Ussr.Hqs
{
	public class TrainingBase : Hq
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<TrainingBase>("sh_orel");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}