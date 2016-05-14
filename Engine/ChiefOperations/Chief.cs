using System;
using System.Linq;
using System.Collections.Generic;
using Midnight.Engine.Cards;
using Midnight.Engine.Battlefield;

namespace Midnight.Engine.ChiefOperations
{
	public class Chief
	{
		private Engine engine;

		public readonly int index;

		public readonly List<Card> cards = new List<Card>();
		public readonly CardFactory cardFactory;

		private int resources = 0;
		private int ownIncrease = 0;

		public Chief (int index)
		{
			this.index = index;
			cardFactory = new CardFactory(this);
		}

		public Chief AddCard (Card card)
		{
			cards.Add(card);
			card.SetChief(this);
			return this;
		}

		public Chief AddCards (Card[] cards)
		{
			foreach (var card in cards) {
				AddCard(card);
			}
			return this;
		}

		public Chief SetEngine (Engine engine)
		{
			this.engine = engine;
			return this;
		}

		public Engine GetEngine ()
		{
			return engine;
		}

		public void PayResources(int value)
		{
			if (value > resources) {
				resources = 0;
			} else {
				resources -= value;
			}
		}

		public void GiveResources(int value)
		{
			resources += value;
		}

		public int GetResources ()
		{
			return resources;
		}

		public void SetResources(int value)
		{
			resources = value;
		}
		
		public int GetTotalIncrease()
		{
			int increase = ownIncrease;

			foreach (Card card in cards) {
				if (card.IsInForefront()) {
					increase += card.GetIncrease();
				}
			}

			return increase;
		}

		public int GetOwnIncrease ()
		{
			return ownIncrease;
		}

		public void SetOwnIncrease (int increase)
		{
			ownIncrease = increase;
		}

		private List<Card> GetLocationCards (Location location)
		{
			return (List<Card>) cards.Where(card => card.IsAt(location));
		}

		public void AddToLocation (Card card, Location location)
		{
			GetLocationCards(location).Add(card);
		}

		public void RemoveFromLocation (Card card, Location location)
		{
			GetLocationCards(location).Remove(card);
		}

		public Platoon GetPlatoonBySubtype (Subtype subtype)
		{
			return (Platoon) cards.First(card => card.IsActivePlatoon() && card.Is(subtype));
		}

		public List<Platoon> GetOrderedPlatoons ()
		{
			var platoons = new List<Platoon>();
			
			foreach (var subtype in Platoon.subtypeOrder) {
				var item = GetPlatoonBySubtype(subtype);

				if (item != null) {
					platoons.Add(item);
				}
			}

			return platoons;
		}

		public Chief GetOpponent ()
		{
			throw new NotImplementedException();
		}

		public void ShuffleDeck ()
		{
			throw new NotImplementedException();
		}

		public Cell GetStartCell ()
		{
			return engine.field.GetCornerCell(index == 1);
		}

		public List<Hq> GetAliveHqs ()
		{
			var hqs = cards
				.Where(card => card.IsActiveHq())
				.Cast<Hq>();

			return (List<Hq>)hqs;
		}

		public Hq GetHq ()
		{
			Card hq = cards.First(card => card.IsActiveHq());

			return hq == null ? null : (Hq)hq;
		}

		public List<Cell> GetFootholdCells ()
		{
			var hqs = GetAliveHqs();

			if (hqs.Count == 0) {
				return engine.field.GetCellsByColumn(GetStartCell().x);
			} else if (hqs.Count == 1) {
				return hqs[0].GetFootholdCells();
			} else {
				return CompileFootholdCells(hqs);
			}
		}

		private List<Cell> CompileFootholdCells (List<Hq> hqs)
		{
			var cells = new List<Cell>();

			foreach (Hq hq in hqs) {
				cells.AddRange(hq.GetFootholdCells());
			}

			return cells;
		}

		public bool IsTurnOwner ()
		{

			throw new NotImplementedException();
		}

		public bool HasHq (Country country)
		{
			return null != GetAliveHqs().First(hq => hq.Is(country));
		}

		public bool HasHq (Subtype subtype)
		{
			return null != GetAliveHqs().First(hq => hq.Is(subtype));
		}

		public bool HasHq (Country country, Subtype subtype)
		{
			return null != GetAliveHqs().First(hq => hq.Is(country) && hq.Is(subtype));
		}
	}
}
