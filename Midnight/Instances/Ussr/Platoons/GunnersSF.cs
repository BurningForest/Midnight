using Midnight.Cards.Enums;
using Midnight.Cards.Types;

namespace Midnight.Instances.Ussr.GunnersSF
{
	public class GunnersSF : Platoon.Enforce
	{
		public static readonly Proto proto = new Proto<GunnersSF>() {
			id = "sp_strelkiuzhnogofronta",
			level = 1,
			type = Type.platoon,
			subtype = Subtype.artillery,
			country = Country.ussr,

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