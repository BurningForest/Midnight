using System;
using Midnight.Cards.Enums;
using Midnight.ChiefOperations;

namespace Midnight.Cards
{
	public class CardLocation
	{
		protected Location? location = null;
		protected readonly Card card;

		internal CardLocation () { }

		public CardLocation (Card card)
		{
			this.card = card;
		}

		public Location? GetValue ()
		{
			return location;
		}

		public void ToReserve ()
		{
			location = Location.Reserve;
		}

		public void ToGraveyard ()
		{
			location = Location.Graveyard;
		}

		public void ToDeck ()
		{
			location = Location.Deck;
		}

		public void ToSupport ()
		{
			location = Location.Support;
		}

		public bool Is (Location? location)
		{
			return this.location == location;
		}

		public bool IsBattlefield () {
			return Is(Location.Battlefield);
		}

		public bool IsSupport () {
			return Is(Location.Support);
		}

		public bool IsReserve () {
			return Is(Location.Reserve);
		}

		public bool IsGraveyard () {
			return Is(Location.Graveyard);
		}

		public bool IsDeck () {
			return Is(Location.Deck);
		}

		public Location? GetCurrent ()
		{
			return location;
		}

		public bool IsNowhere () {
			return Is(null);
		}

		public bool IsForefront ()
		{
			return IsBattlefield() || IsSupport();
		}

		public virtual void CloneFrom (CardLocation source)
		{
			location = source.GetValue();
		}
	}
}
