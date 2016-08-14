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
			var each1 = player.cards.factory.Create<ParisGun>();
			var each2 = player.cards.factory.Create<ParisGun>();

			var hisHq = enemy.cards.factory.CreateDefaultHq<HqGuards>();
			var Spg1 = enemy.cards.factory.Create<TankSpg>();
			var Spg2 = enemy.cards.factory.Create<TankSpg>();
			var Spg3 = enemy.cards.factory.Create<TankSpg>();

			manage.Position(Spg1, field.GetCell(3, 0));
			manage.Position(Spg2, field.GetCell(3, 1));
			manage.Position(Spg3, field.GetCell(3, 2));

			manage.StartGame(enemy);

			manage.Fight(hisHq, myHq);
			manage.Fight(Spg1, myHq);
			manage.Fight(Spg2, myHq);
			manage.Fight(Spg3, myHq);

			Assert.AreEqual(4, myHq.GetDamage());

			manage.EndTurn(enemy);

			Assert.AreEqual(Status.NotAtReserve, manage.Order(each1, Spg1).GetStatus());
			manage.Draw(player, 2);

			Assert.AreEqual(Status.TargetIsInvalid, manage.Order(each1, hisHq).GetStatus());

			manage.EndTurn(player);

			Assert.AreEqual(Status.NotTurnOfSource, manage.Order(each1, hisHq).GetStatus());

			manage.EndTurn(enemy);

			Assert.IsTrue(manage.Order(each1, Spg1).IsValid());
			Assert.IsTrue(each1.IsDead());
			Assert.AreEqual(2, Spg1.GetDamage());
			Assert.AreEqual(2, myHq.GetDamage());

			Assert.IsTrue(manage.Order(each2, Spg1).IsValid());
			Assert.IsTrue(each2.IsDead());
			Assert.IsTrue(Spg1.IsDead());
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
			
			var each = player.cards.factory.Create<ParisGun>();
			var Spg  = enemy.cards.factory.Create<TankSpg>();

			manage.Position(Spg, field.GetCell(3, 2));

			manage.StartGame(player);

			manage.Draw(player);
			manage.Order(each, Spg);

			Assert.AreEqual(2, Spg.GetDamage());
			Assert.IsTrue(each.IsDead());
		}

	}
}
