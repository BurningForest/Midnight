using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Hqs
{
	public class TrainingBase : Hq
	{
		public static readonly Proto proto = new ParameterizedProto<TrainingBase>() {
			ID = "sh_uchebnayachast",
			Level = 1,
			Type = Type.HQ,
			Subtype = Subtype.Beginner,
			Country = Country.USSR,

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