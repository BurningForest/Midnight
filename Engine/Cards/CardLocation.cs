using System;
using Midnight.Engine.Cards.Enums;

namespace Midnight.Engine.Cards
{
	public class CardLocation
	{
		protected Location location = null;
		protected readonly Card card;

		internal CardLocation () { }

		public CardLocation (Card card)
		{
			this.card = card;
		}

		public void ToReserve ()
		{
			location = Location.reserve;
		}

		public void ToGraveyard ()
		{
			location = Location.graveyard;
		}

		public void ToDeck ()
		{
			location = Location.deck;
		}

		public void ToSupport ()
		{
			location = Location.support;
		}

		public bool Is (Location location)
		{
			return this.location == location;
		}

		public bool IsBattlefield () {
			return Is(Location.battlefield);
		}

		public bool IsSupport () {
			return Is(Location.support);
		}

		public bool IsReserve () {
			return Is(Location.reserve);
		}

		public bool IsGraveyard () {
			return Is(Location.graveyard);
		}

		public bool IsDeck () {
			return Is(Location.deck);
		}

		public bool IsNowhere () {
			return Is(null);
		}

		public bool IsForefront ()
		{
			return IsBattlefield() || IsSupport();
		}
	}
}
