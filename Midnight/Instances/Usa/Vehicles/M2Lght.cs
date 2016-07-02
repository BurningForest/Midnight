using Midnight.Abilities.Passive;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class M2Light : LightVehicle
	{
		public static readonly Proto proto = new Proto<M2Light>() {
			id = "uv_m2lt",
			level = 2,
			type = Type.Vehicle,
			subtype = Subtype.Light,
			country = Country.USA,

			power = 1,
			defense = 0,
			toughness = 3,
			increase = 1,
			cost = 1,
		};
		
		public class UsaCamouflage : Camouflage
		{
			public override bool IsActive ()
			{
				return chief.cards.HasHq(Country.USA);
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			abilities.Add(new UsaCamouflage());
		}
	}
}