using Midnight.Cards.Enums;

namespace Midnight.Cards
{
    public class CardLocation
    {
        protected Location? Location;
        protected readonly Card card;

        internal CardLocation() { }

        public CardLocation(Card card)
        {
            this.card = card;
        }

        public Location? GetValue()
        {
            return Location;
        }

        public void ToReserve()
        {
            Location = Enums.Location.Reserve;
        }

        public void ToGraveyard()
        {
            Location = Enums.Location.Graveyard;
        }

        public void ToDeck()
        {
            Location = Enums.Location.Deck;
        }

        public void ToSupport()
        {
            Location = Enums.Location.Support;
        }

        public bool Is(Location? location)
        {
            return this.Location == location;
        }

        public bool IsBattlefield()
        {
            return Is(Enums.Location.Battlefield);
        }

        public bool IsSupport()
        {
            return Is(Enums.Location.Support);
        }

        public bool IsReserve()
        {
            return Is(Enums.Location.Reserve);
        }

        public bool IsGraveyard()
        {
            return Is(Enums.Location.Graveyard);
        }

        public bool IsDeck()
        {
            return Is(Enums.Location.Deck);
        }

        public Location? GetCurrent()
        {
            return Location;
        }

        public bool IsNowhere()
        {
            return Is(null);
        }

        public bool IsForefront()
        {
            return IsBattlefield() || IsSupport();
        }

        public virtual void CloneFrom(CardLocation source)
        {
            Location = source.GetValue();
        }
    }
}
