using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.ChiefOperations;
using Midnight.ChiefOperations.IoOptions;
using Midnight.Core;
using Midnight.Instances.Ussr.Orders;
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

			var HQ     = player.cards.factory.CreateDefaultHq<HqStrike>(); // increase = 4
			var Light  = player.cards.factory.Create<TankLight>();  // cost = 2
			var Spatg  = player.cards.factory.Create<TankSpatg>();  // cost = 2
			var Medium = player.cards.factory.Create<TankMedium>(); // cost = 4
			var Heavy  = player.cards.factory.Create<TankHeavy>();  // cost = 6
			var Spg    = player.cards.factory.Create<TankSpg>();    // cost = 0
			var medic  = player.cards.factory.Create<PlatoonProtectIntendancy>(); // cost = 1

			var hisSpg = enemy.cards.factory.Create<TankSpg>(); // cost = 0, enemy

			manage.SetResources(player, 2);

			manage.Draw(Light); // good
			manage.Draw(medic); // good
			manage.Draw(Heavy); // too expensive
			manage.Draw(hisSpg); // enemies

			manage.Position(Medium, engine.field.GetCell(0, 1));

			player.io.StartGame();

			var options = player.io.options.GetAvailable();

			Assert.AreEqual(3, options.Count); // 1 movement + 2 deployment

			CardOption LightOption = options[0];
			CardOption medicOption = options[2];

			Assert.AreEqual(Light.id, LightOption.cardId);
			Assert.AreEqual(medic.id, medicOption.cardId);

			Assert.AreEqual(null, LightOption.attacks);
			Assert.AreEqual(null, LightOption.moves);
			Assert.AreEqual(null, LightOption.Orders);

			Assert.AreEqual(TargetType.Cell, LightOption.deploys.type);
			Assert.AreEqual(2, LightOption.deploys.cells.Length);

			Assert.AreEqual(1, LightOption.deploys.cells[0].x);
			Assert.AreEqual(0, LightOption.deploys.cells[0].y);

			Assert.AreEqual(1, LightOption.deploys.cells[1].x);
			Assert.AreEqual(1, LightOption.deploys.cells[1].y);

			Assert.AreEqual(TargetType.Global, medicOption.deploys.type);
			Assert.AreEqual(null, medicOption.deploys.cells);

			player.io.Deploy(new Io.Position() {
				cardId = Light.id,
				x = 1,
				y = 0
			});

			var newOptions = player.io.options.GetAvailable();

			Assert.AreEqual(2, newOptions.Count); // 2 movements
			Assert.AreEqual(Light.id, newOptions[0].cardId);
			Assert.AreEqual(Medium.id, newOptions[1].cardId);
		}

		[TestMethod]
		public void MovementOptions ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			var Medium = player.cards.factory.Create<TankMedium>();
			var Spg = enemy.cards.factory.Create<TankSpg>();

			manage.Position(Medium, engine.field.GetCell(0, 2));
			manage.Position(Spg, engine.field.GetCell(1, 2));

			manage.StartGame(player);

			var options = player.io.options.GetAvailable();

			Assert.AreEqual(1, options.Count);
			Assert.AreEqual(null, options[0].deploys);
			Assert.AreEqual(null, options[0].Orders);

			var moves = options[0].moves;

			Assert.AreEqual(2, moves.cells.Length);
			Assert.AreEqual(0, moves.cells[0].x);
			Assert.AreEqual(1, moves.cells[0].y);
			Assert.AreEqual(1, moves.cells[1].x);
			Assert.AreEqual(1, moves.cells[1].y);
		}

		[TestMethod]
		public void AttackOptions ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			var Light = player.cards.factory.Create<TankLight>();
			var Heavy = enemy.cards.factory.Create<TankHeavy>();
			var Spatg = enemy.cards.factory.Create<TankSpatg>();

			manage.Position(Light, engine.field.GetCell(2, 2));
			manage.Position(Heavy, engine.field.GetCell(1, 2));
			manage.Position(Spatg, engine.field.GetCell(3, 2));

			manage.StartGame(player);

			var options = player.io.options.GetAvailable();

			Assert.AreEqual(1, options.Count);
			Assert.AreEqual(null, options[0].deploys);
			Assert.AreEqual(null, options[0].Orders);

			var attacks = options[0].attacks;

			Assert.AreEqual(2, attacks.targets.Length);
			Assert.AreEqual(Heavy.id, attacks.targets[0].targetId);
			Assert.AreEqual(Spatg.id, attacks.targets[1].targetId);
		}

		[TestMethod]
		public void OrderOptions ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			var front = player.cards.factory.Create<HelpForTheFront>();
			var crush = player.cards.factory.Create<CrushTheEnemy>();
			var Spatg = enemy.cards.factory.Create<TankSpatg>();

			manage.SetResources(player, 10);
			manage.Draw(crush);
			manage.Draw(front);
			manage.Position(Spatg, engine.field.GetCell(3, 2));

			manage.StartGame(player);

			var options = player.io.options.GetAvailable();

			Assert.AreEqual(2, options.Count);

			var frontOpt = options[0];
			var crushOpt = options[1];
			
			Assert.AreEqual(null, frontOpt.deploys);
			Assert.AreEqual(null, frontOpt.attacks);
			Assert.AreEqual(null, frontOpt.moves);

			Assert.AreEqual(TargetType.Global, frontOpt.Orders.type);
			Assert.AreEqual(null, frontOpt.Orders.targets);

			Assert.AreEqual(null, crushOpt.deploys);
			Assert.AreEqual(null, crushOpt.attacks);
			Assert.AreEqual(null, crushOpt.moves);

			Assert.AreEqual(TargetType.Card, crushOpt.Orders.type);
			Assert.AreEqual(1, crushOpt.Orders.targets.Length);
			Assert.AreEqual(Spatg.id, crushOpt.Orders.targets[0].targetId);
		}

	}
}
