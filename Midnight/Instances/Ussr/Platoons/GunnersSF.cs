using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.GunnersSF
{
	public class GunnersSF : Platoon.Enforce
	{
		public static readonly Proto proto = new Proto<GunnersSF>() {
			id = "sp_strelkiuzhnogofronta",
			level = 1,
			type = Type.Platoon,
			subtype = Subtype.Artillery,
			country = Country.USSR,

			power = 1,
			defense = 0,
			toughness = 5,
			increase = 1,
			cost = 4,
		};

		public override Proto GetProto ()
		{
			return proto;
		}
	}
}