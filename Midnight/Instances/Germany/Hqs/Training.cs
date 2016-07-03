using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Hqs
{
	public class Training : Hq
	{
        public static readonly Proto proto = new CardProtosRepository()
            .GetParameterizedProto<Training>("gh_pztrs_wunsdorf");

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}