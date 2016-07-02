using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Germany.Platoons
{
	public class ScoutsM : Platoon.Protect
	{
		public static readonly Proto proto = new ParameterizedProto<ScoutsM>() {
			ID = "gp_auskundschaftersderpdmuncheberg",
			Level = 1,
			Type = Type.Platoon,
			Subtype = Subtype.Scout,
			Country = Country.Germany,

			Power = 0,
			Defense = 2,
			Toughness = 7,
			Increase = 0,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}