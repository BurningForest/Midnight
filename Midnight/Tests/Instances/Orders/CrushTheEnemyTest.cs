using Microsoft.VisualStudio.TestTools.UnitTesting;
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

			var field = engine.Field;
			var player = engine.Chiefs[0];
			var enemy = engine.Chiefs[1];

			var crush1 = player.Cards.Factory.Create<CrushTheEnemy>();
			var crush2 = player.Cards.Factory.Create<CrushTheEnemy>();

			var HQ = enemy.Cards.Factory.CreateDefaultHq<HqStrike>();
			var tm = enemy.Cards.Factory.Create<TankMedium>();

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
