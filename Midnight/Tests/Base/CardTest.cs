using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Props;
using Midnight.Cards.Types;
using Midnight.Cards.Vehicles;
using Midnight.Tests.TestInstances;
using Sun.CardProtos.Enums;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class CardTest
	{

		[TestMethod]
		public void CardIs ()
		{
			var card = new TankLight();

			Assert.IsTrue(card is Vehicle);
			Assert.IsTrue(card is LightVehicle);

			Assert.IsTrue(card.Is(Country.USA));
			Assert.IsTrue(card.Is(Type.Vehicle));
			Assert.IsTrue(card.Is(Subtype.Light));
			
			Assert.IsFalse(card.Is(Country.Germany));
			Assert.IsFalse(card.Is(Type.Order));
			Assert.IsFalse(card.Is(Subtype.Heavy));
		}

		[TestMethod]
		public void CardValues ()
		{
			var card = new TankLight();
			card.Reset();

			Assert.AreEqual(2, card.GetCost());
			Assert.AreEqual(1, card.GetIncrease());
			Assert.AreEqual(2, card.GetToughness());
			Assert.AreEqual(1, card.GetPower());
			Assert.AreEqual(0, card.GetDefense());
			Assert.AreEqual(0, card.GetDamage());
		}

		[TestMethod]
		public void CardPropertiesToString ()
		{
			Assert.AreEqual("cost", Property.cost.ToString());
			Assert.AreEqual("increase", Property.increase.ToString());
			Assert.AreEqual("toughness", Property.toughness.ToString());
			Assert.AreEqual("power", Property.power.ToString());
			Assert.AreEqual("defense", Property.defense.ToString());
			Assert.AreEqual("damage", Property.damage.ToString());
		}

		[TestMethod]
		public void CardBaseLocation ()
		{
			var card = new TankLight();

			Assert.IsTrue(card.GetLocation().IsNowhere());
			Assert.IsFalse(card.GetLocation().IsForefront());

			card.GetLocation().ToDeck();
			Assert.IsFalse(card.GetLocation().IsNowhere());
			Assert.IsFalse(card.GetLocation().IsForefront());
			Assert.IsTrue(card.GetLocation().IsDeck());

			card.GetLocation().ToReserve();
			Assert.IsFalse(card.GetLocation().IsDeck());
			Assert.IsFalse(card.GetLocation().IsForefront());
			Assert.IsTrue(card.GetLocation().IsReserve());

			card.GetLocation().ToGraveyard();
			Assert.IsFalse(card.GetLocation().IsReserve());
			Assert.IsFalse(card.GetLocation().IsForefront());
			Assert.IsTrue(card.GetLocation().IsGraveyard());
			Assert.IsTrue(card.IsDead());
		}

		[TestMethod]
		public void CardFieldLocation ()
		{
			var field = BattlefieldTest.CreateField();
			var card = new TankLight();

			Assert.IsTrue(card.GetLocation().IsNowhere());
			Assert.IsFalse(card.GetLocation().IsForefront());
			Assert.IsFalse(card.GetLocation().IsBattlefield());
			Assert.AreEqual(null, card.GetFieldLocation().GetCell());

			card.GetFieldLocation().ToCell(field.GetCell(2, 1));
			Assert.AreEqual(field.GetCell(2, 1), card.GetFieldLocation().GetCell());
			Assert.IsFalse(card.GetLocation().IsNowhere());
			Assert.IsTrue(card.GetLocation().IsForefront());
			Assert.IsTrue(card.GetLocation().IsBattlefield());

			card.GetFieldLocation().ToCell(field.GetCell(3, 2));
			Assert.AreEqual(field.GetCell(3, 2), card.GetFieldLocation().GetCell());
			Assert.AreEqual(card, field.GetCell(3, 2).GetCard());
		}
	}
}
