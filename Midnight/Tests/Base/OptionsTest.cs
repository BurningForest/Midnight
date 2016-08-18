using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.ChiefOperations;
using Midnight.ChiefOperations.IoOptions;
using Midnight.Core;
using Midnight.Instances.Usa.Orders;
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

			var options = player.io.Options.GetAvailable();

			Assert.AreEqual(3, options.Count); // 1 movement + 2 deployment

			CardOption LightOption = options[0];
			CardOption medicOption = options[2];

			Assert.AreEqual(Light.Id, LightOption.CardId);
			Assert.AreEqual(medic.Id, medicOption.CardId);

			Assert.AreEqual(null, LightOption.Attacks);
			Assert.AreEqual(null, LightOption.Moves);
			Assert.AreEqual(null, LightOption.Orders);

			Assert.AreEqual(TargetType.Cell, LightOption.Deploys.Type);
			Assert.AreEqual(2, LightOption.Deploys.Cells.Length);

			Assert.AreEqual(1, LightOption.Deploys.Cells[0].X);
			Assert.AreEqual(0, LightOption.Deploys.Cells[0].Y);

			Assert.AreEqual(1, LightOption.Deploys.Cells[1].X);
			Assert.AreEqual(1, LightOption.Deploys.Cells[1].Y);

			Assert.AreEqual(TargetType.Global, medicOption.Deploys.Type);
			Assert.AreEqual(null, medicOption.Deploys.Cells);

			player.io.Deploy(new Io.Position
			{
				CardId = Light.Id,
				X = 1,
				Y = 0
			});

			var newOptions = player.io.Options.GetAvailable();

			Assert.AreEqual(2, newOptions.Count); // 2 movements
			Assert.AreEqual(Light.Id, newOptions[0].CardId);
			Assert.AreEqual(Medium.Id, newOptions[1].CardId);
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

			var options = player.io.Options.GetAvailable();

			Assert.AreEqual(1, options.Count);
			Assert.AreEqual(null, options[0].Deploys);
			Assert.AreEqual(null, options[0].Orders);

			var moves = options[0].Moves;

			Assert.AreEqual(2, moves.Cells.Length);
			Assert.AreEqual(0, moves.Cells[0].X);
			Assert.AreEqual(1, moves.Cells[0].Y);
			Assert.AreEqual(1, moves.Cells[1].X);
			Assert.AreEqual(1, moves.Cells[1].Y);
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

			var options = player.io.Options.GetAvailable();

			Assert.AreEqual(1, options.Count);
			Assert.AreEqual(null, options[0].Deploys);
			Assert.AreEqual(null, options[0].Orders);

			var attacks = options[0].Attacks;

			Assert.AreEqual(2, attacks.Targets.Length);
			Assert.AreEqual(Heavy.Id, attacks.Targets[0].TargetId);
			Assert.AreEqual(Spatg.Id, attacks.Targets[1].TargetId);
		}

		[TestMethod]
		public void OrderOptions ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			var front = player.cards.factory.Create<FordT>();
			var crush = player.cards.factory.Create<CrushTheEnemy>();
			var Spatg = enemy.cards.factory.Create<TankSpatg>();

			manage.SetResources(player, 10);
			manage.Draw(crush);
			manage.Draw(front);
			manage.Position(Spatg, engine.field.GetCell(3, 2));

			manage.StartGame(player);

			var options = player.io.Options.GetAvailable();

			Assert.AreEqual(2, options.Count);

			var frontOpt = options[0];
			var crushOpt = options[1];
			
			Assert.AreEqual(null, frontOpt.Deploys);
			Assert.AreEqual(null, frontOpt.Attacks);
			Assert.AreEqual(null, frontOpt.Moves);

			Assert.AreEqual(TargetType.Global, frontOpt.Orders.Type);
			Assert.AreEqual(null, frontOpt.Orders.Targets);

			Assert.AreEqual(null, crushOpt.Deploys);
			Assert.AreEqual(null, crushOpt.Attacks);
			Assert.AreEqual(null, crushOpt.Moves);

			Assert.AreEqual(TargetType.Card, crushOpt.Orders.Type);
			Assert.AreEqual(1, crushOpt.Orders.Targets.Length);
			Assert.AreEqual(Spatg.Id, crushOpt.Orders.Targets[0].TargetId);
		}

	}
}
