using System;
using Midnight.Engine.Cards.Enums;

namespace Midnight.Engine.Cards
{
	public class CardLocation
	{
		private Location location = null;

		internal CardLocation () { }

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

		public void ToBattefield ()
		{
			location = Location.battlefield;
		}

		public bool Is (Location location)
		{
			return this.location == location;
		}

		public bool IsBattlefield () {
			return location == Location.battlefield;
		}

		public bool IsSupport () {
			return location == Location.support;
		}

		public bool IsReserve () {
			return location == Location.reserve;
		}

		public bool IsGraveyard () {
			return location == Location.graveyard;
		}

		public bool IsDeck () {
			return location == Location.deck;
		}

		public bool IsNowhere () {
			return location == null;
		}

		public bool IsForefront ()
		{
			return IsBattlefield() || IsSupport();
		}
	}
}
