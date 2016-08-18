using Midnight.Abilities.Positioning;
using Sun.CardProtos.Enums;

namespace Midnight.Cards.Types
{
    public abstract class Platoon : ForefrontCard
    {
        public abstract class Enforce : Platoon { }
        public abstract class Protect : Platoon { }

        public static Subtype[] SubtypeOrder = {
            Subtype.Scout,
            Subtype.Communications,
            Subtype.Artillery,
            Subtype.Medic,
            Subtype.Intendancy,
        };

        public override void InitAbilities()
        {
            base.InitAbilities();

            Abilities.Add(
                new Deployment()
            );
        }
    }
}
