using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Instances.Ussr.Hqs
{
	public class Training : Hq
	{
		public static readonly Proto proto = new Proto() {
			id = "sh_uchebnayachast",
			level = 1,
			type = Type.hq,
			subtype = Subtype.beginner,
			country = Country.ussr,

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