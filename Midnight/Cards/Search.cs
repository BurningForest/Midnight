using Midnight.Cards.Enums;
using Midnight.ChiefOperations;
using Sun.CardProtos.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Midnight.Cards
{
	public class Search
	{
		private bool IsPlayer = false;
		private bool IsEnemy = false;

		private HashSet<Type> types = new HashSet<Type>();
		private HashSet<Subtype> subtypes = new HashSet<Subtype>();
		private HashSet<Location> locations = new HashSet<Location>();

		private readonly Chief chief;

		public Search (Chief chief)
		{
			this.chief = chief;
		}

		public bool IsValid (Card card)
		{
			// Player only
			if (IsPlayer && !IsEnemy && card.IsControlledBy(chief.GetOpponent())) {
				return false;
			}

			// Enemy only
			if (!IsPlayer && IsEnemy && card.IsControlledBy(chief)) {
				return false;
			}

			if (types.Count > 0 && !types.Contains(card.GetProto().Type)) {
				return false;
			}

			if (subtypes.Count > 0 && !subtypes.Contains(card.GetProto().Subtype)) {
				return false;
			}

			if (locations.Count > 0 && !locations.Contains(card.GetLocation().GetCurrent())) {
				return false;
			}

			return true;
		}

		public bool IsValidExists ()
		{
			return GetAllCards().Any(IsValid);
		}

		public Card[] GetAll ()
		{
			return GetAllCards().Where(IsValid).ToArray();
		}

		private IEnumerable<Card> GetAllCards ()
		{
			return new Card[0]
				.Union(chief.cards.GetAll())
				.Union(chief.GetOpponent().cards.GetAll());
		}

		public Search Player ()
		{
			IsPlayer = true;
			return this;
		}

		public Search Enemy ()
		{
			IsEnemy = true;
			return this;
		}

		// type
		public Search Hq ()
		{
			types.Add(Type.HQ);
			return this;
		}

		public Search Vehicle ()
		{
			types.Add(Type.Vehicle);
			return this;
		}

		public Search Platoon ()
		{
			types.Add(Type.Platoon);
			return this;
		}

		public Search Order ()
		{
			types.Add(Type.Order);
			return this;
		}

		// subtype
		public Search Light ()
		{
			subtypes.Add(Subtype.Light);
			return this;
		}

		public Search Medium ()
		{
			subtypes.Add(Subtype.Medium);
			return this;
		}

		public Search Heavy ()
		{
			subtypes.Add(Subtype.Heavy);
			return this;
		}

		public Search Spatg ()
		{
			subtypes.Add(Subtype.Spatg);
			return this;
		}

		public Search Spg ()
		{
			subtypes.Add(Subtype.Spg);
			return this;
		}

		// location
		public Search Forefront ()
		{
			return Battlefield().Support();
		}

		public Search Battlefield ()
		{
			locations.Add(Location.battlefield);
			return this;
		}

		public Search Reserve ()
		{
			locations.Add(Location.reserve);
			return this;
		}

		public Search Graveyard ()
		{
			locations.Add(Location.graveyard);
			return this;
		}

		public Search Support ()
		{
			locations.Add(Location.support);
			return this;
		}

		public Search Deck ()
		{
			locations.Add(Location.deck);
			return this;
		}
	}
}
