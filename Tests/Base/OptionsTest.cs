using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.ChiefOperations;
using Midnight.ChiefOperations.IoOptions;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class OptionsTest
	{
		[TestMethod]
		public void DeploymentOptions ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			var hq     = player.cards.factory.CreateDefaultHq<HqStrike>(); // increase = 4
			var light  = player.cards.factory.Create<TankLight>();  // cost = 2
			var spatg  = player.cards.factory.Create<TankSpatg>();  // cost = 2
			var medium = player.cards.factory.Create<TankMedium>(); // cost = 4
			var heavy  = player.cards.factory.Create<TankHeavy>();  // cost = 6
			var spg    = player.cards.factory.Create<TankSpg>();    // cost = 0
			var medic  = player.cards.factory.Create<PlatoonProtectIntendancy>(); // cost = 1

			var hisSpg = enemy.cards.factory.Create<TankSpg>(); // cost = 0, enemy

			manage.SetResources(player, 2);

			manage.Draw(light); // good
			manage.Draw(medic); // good
			manage.Draw(heavy); // too expensive
			manage.Draw(hisSpg); // enemies

			manage.Position(medium, engine.field.GetCell(0, 1));

			manage.StartGame(player);

			var options = player.io.options.GetAvailable();

			Assert.AreEqual(3, options.Count); // 1 movement + 2 deployment

			CardOption lightOption = options[0];
			CardOption medicOption = options[2];

			Assert.AreEqual(light.id, lightOption.cardId);
			Assert.AreEqual(medic.id, medicOption.cardId);

			Assert.AreEqual(null, lightOption.attacks);
			Assert.AreEqual(null, lightOption.moves);
			Assert.AreEqual(null, lightOption.orders);

			Assert.AreEqual(TargetType.Cell, lightOption.deploys.type);
			Assert.AreEqual(2, lightOption.deploys.cells.Length);

			Assert.AreEqual(1, lightOption.deploys.cells[0].x);
			Assert.AreEqual(0, lightOption.deploys.cells[0].y);

			Assert.AreEqual(1, lightOption.deploys.cells[1].x);
			Assert.AreEqual(1, lightOption.deploys.cells[1].y);

			Assert.AreEqual(TargetType.Global, medicOption.deploys.type);
			Assert.AreEqual(null, medicOption.deploys.cells);

			player.io.Deploy(new Io.Position() {
				cardId = light.id,
				x = 1,
				y = 0
			});

			var newOptions = player.io.options.GetAvailable();

			Assert.AreEqual(2, newOptions.Count); // 2 movements
			Assert.AreEqual(light.id, newOptions[0].cardId);
			Assert.AreEqual(medium.id, newOptions[1].cardId);
		}
	}
}
