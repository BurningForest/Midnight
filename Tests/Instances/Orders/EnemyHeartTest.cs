using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Instances.Usa.Orders;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Orders
{
	[TestClass]
	public class EnemyHeartTest
	{

		[TestMethod]
		public void EnemyHeart ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field  = engine.field;
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			manage.SetResources(player, 50);

			var heart1 = player.cards.factory.Create<EnemyHeart>();
			var heart2 = player.cards.factory.Create<EnemyHeart>();

			var hq = enemy.cards.factory.CreateDefaultHq<HqStrike>();
			var tank = enemy.cards.factory.Create<TankMedium>();

			manage.Position(tank, field.GetCell(2, 2));
			manage.Draw(player, 2);

			manage.StartGame(player);

			Assert.IsTrue(manage.Order(heart1, hq).IsValid());
			Assert.AreEqual(2, hq.GetDamage());

			Assert.AreEqual(Status.NotAtReserve, manage.Order(heart1, hq).GetStatus());

			Assert.IsTrue(manage.Order(heart2, tank).IsValid());
			Assert.AreEqual(2, tank.GetDamage());

		}

	}
}
