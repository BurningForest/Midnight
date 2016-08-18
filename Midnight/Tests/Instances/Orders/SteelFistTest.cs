using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Instances.Ussr.Orders;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Orders
{
	[TestClass]
	public class SteelFistTest
	{

		[TestMethod]
		public void SteelFist ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field = engine.Field;
			var player = engine.Chiefs[0];
			var enemy = engine.Chiefs[1];

			var crush = player.Cards.Factory.Create<SteelFist>();

			var HQ = enemy.Cards.Factory.CreateDefaultHq<HqStrike>();
			var tm = enemy.Cards.Factory.Create<TankMedium>();

			manage.SetResources(player, 20);
			manage.Position(tm, field.GetCell(2, 2));
			manage.Draw(player);

			manage.StartGame(player);

			Assert.AreEqual(Status.TargetIsInvalid, manage.Order(crush, tm).GetStatus());
			Assert.IsTrue(manage.Order(crush, HQ).IsValid());
			Assert.AreEqual(5, HQ.GetDamage());
		}

	}
}
