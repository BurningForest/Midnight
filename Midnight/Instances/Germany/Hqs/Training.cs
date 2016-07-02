using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Hqs
{
	public class Training : Hq
	{
		public static readonly Proto proto = new ParameterizedProto<Training>() {
			ID = "gh_trainingslager",
			Level = 1,
			Type = Type.HQ,
			Subtype = Subtype.Beginner,
			Country = Country.Germany,

			Power = 2,
			Toughness = 18,
			Increase = 5,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}