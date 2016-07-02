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

			var HQ = player.cards.factory.CreateDefaultHq<HqGuards>();
			var Spg1 = enemy.cards.factory.Create<TankBigSpg>();
			var Spg2 = enemy.cards.factory.Create<TankBigSpg>();

			manage.Position(Spg1, engine.field.GetCell(2, 2));
			manage.Position(Spg2, engine.field.GetCell(1, 2));

			manage.StartGame(enemy);

			manage.Fight(Spg1, HQ);

			Assert.IsFalse(HQ.IsDead());
			Assert.AreEqual(null, final.action);

			manage.Fight(Spg2, HQ);

			Assert.IsTrue(HQ.IsDead());
			Assert.AreNotEqual(null, final.action);
			Assert.AreEqual(1, final.count);
			Assert.AreEqual(final.action.trigger, Final.Trigger.HqDeath);
		}
	}
}
