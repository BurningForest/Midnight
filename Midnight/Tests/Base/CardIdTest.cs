﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			
			var Spg = engine.chiefs[0].cards.factory.Create<TankSpg>();
			var Light = engine.chiefs[0].cards.factory.Create<TankLight>();
			var Medium = engine.chiefs[1].cards.factory.Create<TankMedium>();
			var HQ = engine.chiefs[0].cards.factory.CreateDefaultHq<HqConsol>();

			Assert.AreEqual(1, Spg.id);
			Assert.AreEqual(2, Light.id);
			Assert.AreEqual(3, Medium.id);
			Assert.AreEqual(4, HQ.id);
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