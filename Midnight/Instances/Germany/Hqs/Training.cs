using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.Instances.Germany.Hqs
{
	public class Training : Hq
	{
        public static readonly Proto Proto = new CardProtosRepository()
            .GetParameterizedProto<Training>("gh_wunsdorf");

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}