using System.Collections.Generic;
using System.Linq;
using Midnight.Cards.Enums;
using Midnight.ChiefOperations;
using Sun.CardProtos.Enums;

namespace Midnight.Cards
{
    public class Search
    {
        private bool _isPlayer;
        private bool _isEnemy;

        private readonly HashSet<Type> _types = new HashSet<Type>();
        private readonly HashSet<Subtype> _subtypes = new HashSet<Subtype>();
        private readonly HashSet<Location?> _locations = new HashSet<Location?>();

        private readonly Chief _chief;

        public Search(Chief chief)
        {
            _chief = chief;
        }

        public bool IsValid(Card card)
        {
            // Player only
            if (_isPlayer && !_isEnemy && card.IsControlledBy(_chief.GetOpponent()))
            {
                return false;
            }

            // Enemy only
            if (!_isPlayer && _isEnemy && card.IsControlledBy(_chief))
            {
                return false;
            }

            if (_types.Count > 0 && !_types.Contains(card.GetProto().Type))
            {
                return false;
            }

            if (_subtypes.Count > 0 && !_subtypes.Contains(card.GetProto().Subtype))
            {
                return false;
            }

            if (_locations.Count > 0 && !_locations.Contains(card.GetLocation().GetCurrent()))
            {
                return false;
            }

            return true;
        }

        public bool IsValidExists()
        {
            return GetAllCards().Any(IsValid);
        }

        public Card[] GetAll()
        {
            return GetAllCards().Where(IsValid).ToArray();
        }

        private IEnumerable<Card> GetAllCards()
        {
            return new Card[0]
                .Union(_chief.Cards.GetAll())
                .Union(_chief.GetOpponent().Cards.GetAll());
        }

        public Search Player()
        {
            _isPlayer = true;
            return this;
        }

        public Search Enemy()
        {
            _isEnemy = true;
            return this;
        }

        // type
        public Search Hq()
        {
            _types.Add(Type.HQ);
            return this;
        }

        public Search Vehicle()
        {
            _types.Add(Type.Vehicle);
            return this;
        }

        public Search Platoon()
        {
            _types.Add(Type.Platoon);
            return this;
        }

        public Search Order()
        {
            _types.Add(Type.Order);
            return this;
        }

        // subtype
        public Search Light()
        {
            _subtypes.Add(Subtype.Light);
            return this;
        }

        public Search Medium()
        {
            _subtypes.Add(Subtype.Medium);
            return this;
        }

        public Search Heavy()
        {
            _subtypes.Add(Subtype.Heavy);
            return this;
        }

        public Search Spatg()
        {
            _subtypes.Add(Subtype.Spatg);
            return this;
        }

        public Search Spg()
        {
            _subtypes.Add(Subtype.Spg);
            return this;
        }

        // location
        public Search Forefront()
        {
            return Battlefield().Support();
        }

        public Search Battlefield()
        {
            _locations.Add(Location.Battlefield);
            return this;
        }

        public Search Reserve()
        {
            _locations.Add(Location.Reserve);
            return this;
        }

        public Search Graveyard()
        {
            _locations.Add(Location.Graveyard);
            return this;
        }

        public Search Support()
        {
            _locations.Add(Location.Support);
            return this;
        }

        public Search Deck()
        {
            _locations.Add(Location.Deck);
            return this;
        }
    }
}
