using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Platoons
{
	public class ScoutsM : Platoon.Protect
	{
		public static readonly Proto proto = new Proto<ScoutsM>() {
			id = "gp_auskundschaftersderpdmuncheberg",
			level = 1,
			type = Type.Platoon,
			subtype = Subtype.Scout,
			country = Country.Germany,

			power = 0,
			defense = 2,
			toughness = 7,
			increase = 0,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}