using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Hqs
{
	public class TrainingCamp : Hq
	{
		public static readonly Proto proto = new ParameterizedProto<TrainingCamp>() {
			ID = "uh_trainingcamp",
			Level = 1,
			Type = Type.HQ,
			Subtype = Subtype.Beginner,
			Country = Country.USA,

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