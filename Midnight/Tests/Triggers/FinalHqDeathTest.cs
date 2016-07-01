using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;
using Midnight.Actions;

namespace Midnight.Tests.Triggers
{
	[TestClass]
	public class FinalHqDeathTest
	{
		[TestMethod]
		public void FinalHqDeath ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			engine.triggers.Register<FinalDeckOut>();
			engine.triggers.Register<FinalHqDeath>();

			var final = new FinalListener(engine);

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			var hq = player.cards.factory.CreateDefaultHq<HqGuards>();
			var spg1 = enemy.cards.factory.Create<TankBigSpg>();
			var spg2 = enemy.cards.factory.Create<TankBigSpg>();

			manage.Position(spg1, engine.field.GetCell(2, 2));
			manage.Position(spg2, engine.field.GetCell(1, 2));

			manage.StartGame(enemy);

			manage.Fight(spg1, hq);

			Assert.IsFalse(hq.IsDead());
			Assert.AreEqual(null, final.action);

			manage.Fight(spg2, hq);

			Assert.IsTrue(hq.IsDead());
			Assert.AreNotEqual(null, final.action);
			Assert.AreEqual(1, final.count);
			Assert.AreEqual(final.action.trigger, Final.Trigger.HqDeath);
		}
	}
}
