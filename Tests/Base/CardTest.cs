using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Engine.Cards;
using Midnight.Engine.Cards.Enums;
using Midnight.Engine.Cards.Types;
using Midnight.Engine.Cards.Vehicles;
using Midnight.Tests.Instances;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class CardTest
	{

		[TestMethod]
		public void CardIs ()
		{
			var card = new LightTank();

			Assert.IsTrue(card is Vehicle);
			Assert.IsTrue(card is LightVehicle);

			Assert.IsTrue(card.Is(Country.usa));
			Assert.IsTrue(card.Is(Type.vehicle));
			Assert.IsTrue(card.Is(Subtype.light));

			Assert.IsFalse(card.Is(Country.germany));
			Assert.IsFalse(card.Is(Type.order));
			Assert.IsFalse(card.Is(Subtype.heavy));
		}

		[TestMethod]
		public void CardValues ()
		{
			var card = new LightTank();

			Assert.AreEqual(1, card.GetCost());
			Assert.AreEqual(1, card.GetIncrease());
			Assert.AreEqual(2, card.GetToughness());
			Assert.AreEqual(1, card.GetPower());
			Assert.AreEqual(0, card.GetDefense());
		}

		[TestMethod]
		public void CardBaseLocation ()
		{
			var card = new LightTank();

			Assert.IsTrue(card.IsNowhere());
			Assert.IsFalse(card.IsInForefront());

			card.ToDeck();
			Assert.IsFalse(card.IsNowhere());
			Assert.IsFalse(card.IsInForefront());
			Assert.IsTrue(card.IsAtDeck());

			card.ToReserve();
			Assert.IsFalse(card.IsAtDeck());
			Assert.IsFalse(card.IsInForefront());
			Assert.IsTrue(card.IsAtReserve());

			card.ToGraveyard();
			Assert.IsFalse(card.IsAtReserve());
			Assert.IsFalse(card.IsInForefront());
			Assert.IsTrue(card.IsAtGraveyard());
			Assert.IsTrue(card.IsDead());
		}

		[TestMethod]
		public void CardFieldLocation ()
		{
			var field = BattlefieldTest.CreateField();
			var card = new LightTank();

			Assert.IsTrue(card.IsNowhere());
			Assert.IsFalse(card.IsInForefront());
			Assert.IsFalse(card.IsAtBattlefield());
			Assert.AreEqual(null, card.GetCell());

			card.ToCell(field.GetCell(2, 1));
			Assert.AreEqual(field.GetCell(2, 1), card.GetCell());
			Assert.IsFalse(card.IsNowhere());
			Assert.IsTrue(card.IsInForefront());
			Assert.IsTrue(card.IsAtBattlefield());

			card.ToCell(field.GetCell(3, 2));
			Assert.AreEqual(field.GetCell(3, 2), card.GetCell());
		}
	}
}
