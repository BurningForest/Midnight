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
			
			var spg = engine.chiefs[0].cards.factory.Create<TankSpg>();
			var light = engine.chiefs[0].cards.factory.Create<TankLight>();
			var medium = engine.chiefs[1].cards.factory.Create<TankMedium>();
			var hq = engine.chiefs[0].cards.factory.CreateDefaultHq<HqConsol>();

			Assert.AreEqual(1, spg.id);
			Assert.AreEqual(2, light.id);
			Assert.AreEqual(3, medium.id);
			Assert.AreEqual(4, hq.id);
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
