using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Hqs
{
    public class Training : Hq
	{
		public static readonly Proto proto = new Proto<Training>() {
			id = "uh_trainingcamp",
			level = 1,
			type = Type.HQ,
			subtype = Subtype.Beginner,
			country = Country.USA,

			power = 2,
			toughness = 18,
			increase = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}