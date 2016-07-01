using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Positioning
{
	[TestClass]
	public class DeploymentTest
	{
		[TestMethod]
		public void Deployment ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);
			
			engine.triggers.Register<TurnAddResources>();

			var field  = engine.field;
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			player.cards.factory.CreateDefaultHq<HqConsol>();
			enemy .cards.factory.CreateDefaultHq<HqStrike>();

			var medium = player.cards.factory.Create<TankMedium>();
			var heavy  = player.cards.factory.Create<TankHeavy>();

			var light = new[] {
				enemy.cards.factory.Create<TankLight>(),
				enemy.cards.factory.Create<TankLight>(),
				enemy.cards.factory.Create<TankLight>()
			};

			manage.Draw(medium);
			manage.Draw(heavy);
			manage.Draw(enemy, 3);

			manage.StartGame(player);

			Assert.AreEqual(3, enemy.cards.CountLocation(Location.reserve));
			Assert.AreEqual(5, player.GetTotalIncrease());
			Assert.AreEqual(5, player.GetResources());
			Assert.AreEqual(4, enemy.GetTotalIncrease());
			Assert.AreEqual(0, enemy.GetResources());

			var heavyDeploy = manage.Deploy(heavy, field.GetCell(1, 0));
			Assert.AreEqual(Status.NotEnoughResources, heavyDeploy.GetStatus());
			Assert.IsTrue(heavy.GetLocation().IsReserve());

			Assert.AreEqual(5, player.GetTotalIncrease());
			Assert.AreEqual(5, player.GetResources());

			var mediumDeploy = manage.Deploy(medium, field.GetCell(1, 1));
			Assert.IsTrue(mediumDeploy.IsValid());
			Assert.IsTrue(medium.GetLocation().IsBattlefield());
			Assert.AreEqual(field.GetCell(1, 1), medium.GetFieldLocation().GetCell());

			Assert.AreEqual(6, player.GetTotalIncrease());
			Assert.AreEqual(1, player.GetResources());

			manage.EndTurn(player);

			var deploy = new[] {
				manage.Deploy(light[0], field.GetCell(4, 1)),
				manage.Deploy(light[1], field.GetCell(3, 1)),
				manage.Deploy(light[2], field.GetCell(3, 2)),
			};

			Assert.IsTrue(deploy[0].IsValid());
			Assert.IsTrue(deploy[1].IsValid());
			Assert.IsFalse(deploy[2].IsValid());

			Assert.AreEqual(Status.NotEnoughResources, deploy[2].GetStatus());

			Assert.AreEqual(field.GetCell(4, 1), light[0].GetFieldLocation().GetCell());
			Assert.AreEqual(field.GetCell(3, 1), light[1].GetFieldLocation().GetCell());

			Assert.IsTrue(light[0].GetLocation().IsBattlefield());
			Assert.IsTrue(light[1].GetLocation().IsBattlefield());
			Assert.IsTrue(light[2].GetLocation().IsReserve());

			manage.EndTurn(enemy);

			heavyDeploy = manage.Deploy(heavy, field.GetCell(1, 0));
			Assert.IsTrue(heavyDeploy.IsValid());
			Assert.IsTrue(heavy.GetLocation().IsBattlefield());
			Assert.AreEqual(field.GetCell(1, 0), heavy.GetFieldLocation().GetCell());


		}
	}
}
