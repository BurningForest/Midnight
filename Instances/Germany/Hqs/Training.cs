using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Instances.Germany.Hqs
{
	public class Training : Hq
	{
		public static readonly Proto proto = new Proto() {
			id = "gh_trainingslager",
			level = 1,
			type = Type.hq,
			subtype = Subtype.beginner,
			country = Country.germany,

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