using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Instances.Germany.Orders;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Orders
{
	[TestClass]
	public class EachBattleTest
	{

		[TestMethod]
		public void EachBattle ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field = engine.field;
			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			manage.SetResources(player, 50);

			var myHq = player.cards.factory.CreateDefaultHq<HqGuards>();
			var each1 = player.cards.factory.Create<EachBattle>();
			var each2 = player.cards.factory.Create<EachBattle>();

			var hisHq = enemy.cards.factory.CreateDefaultHq<HqGuards>();
			var spg1 = enemy.cards.factory.Create<TankSpg>();
			var spg2 = enemy.cards.factory.Create<TankSpg>();
			var spg3 = enemy.cards.factory.Create<TankSpg>();

			manage.Position(spg1, field.GetCell(3, 0));
			manage.Position(spg2, field.GetCell(3, 1));
			manage.Position(spg3, field.GetCell(3, 2));

			manage.StartGame(enemy);

			manage.Fight(hisHq, myHq);
			manage.Fight(spg1, myHq);
			manage.Fight(spg2, myHq);
			manage.Fight(spg3, myHq);

			Assert.AreEqual(4, myHq.GetDamage());

			manage.EndTurn(enemy);

			Assert.AreEqual(Status.NotAtReserve, manage.Order(each1, spg1).GetStatus());
			manage.Draw(player, 2);

			Assert.AreEqual(Status.TargetIsInvalid, manage.Order(each1, hisHq).GetStatus());

			manage.EndTurn(player);

			Assert.AreEqual(Status.NotTurnOfSource, manage.Order(each1, hisHq).GetStatus());

			manage.EndTurn(enemy);

			Assert.IsTrue(manage.Order(each1, spg1).IsValid());
			Assert.IsTrue(each1.IsDead());
			Assert.AreEqual(2, spg1.GetDamage());
			Assert.AreEqual(2, myHq.GetDamage());

			Assert.IsTrue(manage.Order(each2, spg1).IsValid());
			Assert.IsTrue(each2.IsDead());
			Assert.IsTrue(spg1.IsDead());
			Assert.AreEqual(0, myHq.GetDamage());
		}

		[TestMethod]
		public void EachBattleWithoutHq ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field  = engine.field;
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			manage.SetResources(player, 50);
			
			var each = player.cards.factory.Create<EachBattle>();
			var spg  = enemy.cards.factory.Create<TankSpg>();

			manage.Position(spg, field.GetCell(3, 2));

			manage.StartGame(player);

			manage.Draw(player, 1);
			manage.Order(each, spg);

			Assert.AreEqual(2, spg.GetDamage());
			Assert.IsTrue(each.IsDead());
		}

	}
}
