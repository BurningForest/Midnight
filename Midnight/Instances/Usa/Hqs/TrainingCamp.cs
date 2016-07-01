using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Instances.Usa.Hqs
{
	public class TrainingCamp : Hq
	{
		public static readonly Proto proto = new Proto<TrainingCamp>() {
			id = "uh_trainingcamp",
			level = 1,
			type = Type.hq,
			subtype = Subtype.beginner,
			country = Country.usa,

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