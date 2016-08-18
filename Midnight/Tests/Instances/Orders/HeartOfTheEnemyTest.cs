using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Instances.Ussr.Orders;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Orders
{
	[TestClass]
	public class HeartOfTheEnemyTest
	{

		[TestMethod]
		public void HeartOfTheEnemy ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field  = engine.Field;
			var player = engine.Chiefs[0];
			var enemy  = engine.Chiefs[1];

			manage.SetResources(player, 50);

			var heart1 = player.Cards.Factory.Create<IlyaMuromets>();
			var heart2 = player.Cards.Factory.Create<IlyaMuromets>();

			var HQ = enemy.Cards.Factory.CreateDefaultHq<HqStrike>();
			var tank = enemy.Cards.Factory.Create<TankMedium>();

			manage.Position(tank, field.GetCell(2, 2));
			manage.Draw(player, 2);

			manage.StartGame(player);

			Assert.IsTrue(manage.Order(heart1, HQ).IsValid());
			Assert.AreEqual(2, HQ.GetDamage());

			Assert.AreEqual(Status.NotAtReserve, manage.Order(heart1, HQ).GetStatus());

			Assert.IsTrue(manage.Order(heart2, tank).IsValid());
			Assert.AreEqual(2, tank.GetDamage());

		}

	}
}
