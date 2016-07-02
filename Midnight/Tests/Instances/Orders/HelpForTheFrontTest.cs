using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Instances.Ussr.Orders;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Orders
{
	[TestClass]
	public class HelpForTheFrontTest
	{

		[TestMethod]
		public void HelpForTheFront ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field = engine.field;
			var player = engine.chiefs[0];

			var HQ = player.cards.factory.CreateDefaultHq<HqStrike>();
			var help = player.cards.factory.Create<HelpForTheFront>();
			var tank = player.cards.factory.Create<TankMedium>();

			manage.Draw(help);
			manage.Damage(6, HQ, HQ);

			Assert.AreEqual(6, HQ.GetDamage());

			manage.Heal(1, HQ, tank);

			Assert.AreEqual(5, HQ.GetDamage());

			manage.SetResources(player, 10);

			manage.StartGame(player);

			Assert.AreEqual(5, HQ.GetDamage());
			Assert.IsTrue(tank.GetLocation().IsDeck());

			Assert.IsTrue(manage.Order(help).IsValid());

			Assert.IsTrue(tank.GetLocation().IsReserve());
			Assert.AreEqual(3, HQ.GetDamage());
		}

	}
}
