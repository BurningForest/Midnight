using System;
using Midnight.Cards;
using Midnight.Cards.Types;
using Sun.CardProtos;

namespace Midnight.ChiefOperations
{
    public class CardFactory
    {
        private readonly Chief _chief;

        public CardFactory(Chief chief)
        {
            _chief = chief;
        }

        private Card Initialize(Card card)
        {
            _chief.Cards.Add(card);
            card.SetChief(_chief);
            card.SetId(_chief.GetEngine().cache.Register(card));
            card.Reset();
            card.InitAbilities();
            return card;
        }

        public Card Create(Proto proto)
        {
            var card = Initialize((Card)proto.Produce());
            card.GetLocation().ToDeck();
            return card;
        }

        public Hq CreateDefaultHq(Proto proto)
        {
            if (_chief.GetStartCell().IsBusy())
            {
                throw new Exception("Start cell is busy for Hq");
            }

            var card = (Hq)Initialize((Card)proto.Produce());
            card.GetFieldLocation().ToCell(_chief.GetStartCell());
            return card;
        }

        public TCard Create<TCard>()
            where TCard : Card, new()
        {
            var card = (TCard)Initialize(new TCard());
            card.GetLocation().ToDeck();
            return card;
        }

        public TCard CreateDefaultHq<TCard>()
            where TCard : Hq, new()
        {
            if (_chief.GetStartCell().IsBusy())
            {
                throw new Exception("Start cell is busy for Hq");
            }

            var card = (TCard)Initialize(new TCard());
            card.GetFieldLocation().ToCell(_chief.GetStartCell());
            return card;
        }
    }
}
