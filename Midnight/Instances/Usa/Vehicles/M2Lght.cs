using Midnight.Abilities.Passive;
using Midnight.Cards.Enums;
using Midnight.Cards.Vehicles;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Instances.Usa.Vehicles
{
	public class M2Light : LightVehicle
	{
		public static readonly Proto proto = new ParameterizedProto<M2Light>() {
			ID = "uv_m2lt",
			Level = 2,
			Type = Type.Vehicle,
			Subtype = Subtype.Light,
			Country = Country.USA,

			Power = 1,
			Defense = 0,
			Toughness = 3,
			Increase = 1,
			Cost = 1,
		};
		
		public class UsaCamouflage : Camouflage
		{
			public override bool IsActive ()
			{
				return Chief.Cards.HasHq(Country.USA);
			}
		}

		public override Proto GetProto ()
		{
			return proto;
		}

		public override void InitAbilities ()
		{
			base.InitAbilities();

			Abilities.Add(new UsaCamouflage());
		}
	}
}