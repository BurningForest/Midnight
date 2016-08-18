﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Instances.Ussr.Orders;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Orders
{
	[TestClass]
	public class CrushTheEnemyTest
	{

		[TestMethod]
		public void CrushTheEnemy ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field = engine.field;
			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			var crush1 = player.cards.factory.Create<CrushTheEnemy>();
			var crush2 = player.cards.factory.Create<CrushTheEnemy>();

			var HQ = enemy.cards.factory.CreateDefaultHq<HqStrike>();
			var tm = enemy.cards.factory.Create<TankMedium>();

			manage.Position(tm, field.GetCell(2, 2));
			manage.Draw(player, 2);

			manage.StartGame(player);

			Assert.IsTrue(manage.Order(crush1, HQ).IsValid());
			Assert.IsTrue(manage.Order(crush2, tm).IsValid());
			Assert.AreEqual(1, HQ.GetDamage());
			Assert.AreEqual(1, tm.GetDamage());
		}

	}
}