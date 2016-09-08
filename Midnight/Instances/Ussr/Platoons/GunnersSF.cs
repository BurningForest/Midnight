using Midnight.Cards.Types;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Ussr.Platoons
{
	public class GunnersSF : Platoon.Enforce
	{
		public static readonly Proto Proto = new ParameterizedProto<GunnersSF>() {
			ID = "sp_strelkiuzhnogofronta",
			Level = 1,
			Type = Type.Platoon,
			Subtype = Subtype.Artillery,
			Country = Country.USSR,

			Power = 1,
			Defense = 0,
			Toughness = 5,
			Increase = 1,
			Cost = 4,
		};

		public override Proto GetProto ()
		{
			return Proto;
		}
	}
}