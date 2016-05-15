using Midnight.Engine.Cards;
using Midnight.Engine.Cards.Types;
using System;

namespace Midnight.Engine.ChiefOperations
{
	public class CardFactory
	{
		private readonly Chief chief;

		public CardFactory (Chief chief)
		{
			this.chief = chief;
		}

		public TCard Create<TCard> ()
			where TCard : Card, new()
		{
			var card = new TCard();
			chief.AddCard(card);
			card.InitAbilities();
			card.GetLocation().ToDeck();
			return card;
		}

		public TCard CreateDefaultHq<TCard> ()
			where TCard : Hq, new()
		{
			if (chief.GetStartCell().IsBusy()) {
				throw new Exception("Cell is busy");
			}

			var card = new TCard();
			chief.AddCard(card);
			card.InitAbilities();
			card.GetFieldLocation().ToCell(chief.GetStartCell());
			return card;
		}

		public CardFactory AddDefault<TCard> (int count)
			where TCard : Card, new()
		{
			for (int i = 0; i < count; i++) {
				Create<TCard>();
			}
			return this;
		}

		public CardFactory AddDefault<TCard> ()
			where TCard : Card, new()
		{
			return AddDefault<TCard>(0);
		}

		public CardFactory AddDefaultHq<TCard> ()
			where TCard : Hq, new()
		{
			CreateDefaultHq<TCard>();
			return this;
		}
	}
}
