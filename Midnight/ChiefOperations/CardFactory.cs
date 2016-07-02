using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Sun.CardProtos;
using System;

namespace Midnight.ChiefOperations
{
	public class CardFactory
	{
		private readonly Chief chief;

		public CardFactory (Chief chief)
		{
			this.chief = chief;
		}

		private Card Initialize(Card card)
		{
			chief.cards.Add(card);
			card.SetChief(chief);
			card.SetId(chief.GetEngine().cache.Register(card));
			card.Reset();
			card.InitAbilities();
			return card;
		}

		public Card Create (Proto proto)
		{
			var card = Initialize((Card)proto.Produce());
			card.GetLocation().ToDeck();
			return card;
		}

		public Hq CreateDefaultHq (Proto proto)
		{
			if (chief.GetStartCell().IsBusy()) {
				throw new Exception("Start cell is busy for Hq");
			}

			var card = (Hq)Initialize((Card)proto.Produce());
			card.GetFieldLocation().ToCell(chief.GetStartCell());
			return card;
		}

		public TCard Create<TCard> ()
			where TCard : Card, new()
		{
			var card = (TCard)Initialize(new TCard());
			card.GetLocation().ToDeck();
			return card;
		}

		public TCard CreateDefaultHq<TCard> ()
			where TCard : Hq, new()
		{
			if (chief.GetStartCell().IsBusy()) {
				throw new Exception("Start cell is busy for Hq");
			}

			var card = (TCard)Initialize(new TCard());
			card.GetFieldLocation().ToCell(chief.GetStartCell());
			return card;
		}
	}
}
