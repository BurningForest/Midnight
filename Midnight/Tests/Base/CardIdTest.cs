using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using System;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class CardIdTest
	{

		[TestMethod]
		public void CardId ()
		{
			var engine = new Engine();
			
			var Spg = engine.chiefs[0].Cards.Factory.Create<TankSpg>();
			var Light = engine.chiefs[0].Cards.Factory.Create<TankLight>();
			var Medium = engine.chiefs[1].Cards.Factory.Create<TankMedium>();
			var HQ = engine.chiefs[0].Cards.Factory.CreateDefaultHq<HqConsol>();

			Assert.AreEqual(1, Spg.Id);
			Assert.AreEqual(2, Light.Id);
			Assert.AreEqual(3, Medium.Id);
			Assert.AreEqual(4, HQ.Id);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CacheDuplicateid ()
		{
			var cache = new Cache();
			var card = new TankLight();
			cache.ManualRegister(card, 1);
			cache.ManualRegister(card, 1);
		}

	}
}
