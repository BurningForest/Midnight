﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

			var Medium = player.cards.factory.Create<TankMedium>();
			var Heavy  = player.cards.factory.Create<TankHeavy>();

			var Light = new[] {
				enemy.cards.factory.Create<TankLight>(),
				enemy.cards.factory.Create<TankLight>(),
				enemy.cards.factory.Create<TankLight>()
			};

			manage.Draw(Medium);
			manage.Draw(Heavy);
			manage.Draw(enemy, 3);

			manage.StartGame(player);

			Assert.AreEqual(3, enemy.cards.CountLocation(Location.Reserve));
			Assert.AreEqual(5, player.GetTotalIncrease());
			Assert.AreEqual(5, player.GetResources());
			Assert.AreEqual(4, enemy.GetTotalIncrease());
			Assert.AreEqual(0, enemy.GetResources());

			var HeavyDeploy = manage.Deploy(Heavy, field.GetCell(1, 0));
			Assert.AreEqual(Status.NotEnoughResources, HeavyDeploy.GetStatus());
			Assert.IsTrue(Heavy.GetLocation().IsReserve());

			Assert.AreEqual(5, player.GetTotalIncrease());
			Assert.AreEqual(5, player.GetResources());

			var MediumDeploy = manage.Deploy(Medium, field.GetCell(1, 1));
			Assert.IsTrue(MediumDeploy.IsValid());
			Assert.IsTrue(Medium.GetLocation().IsBattlefield());
			Assert.AreEqual(field.GetCell(1, 1), Medium.GetFieldLocation().GetCell());

			Assert.AreEqual(6, player.GetTotalIncrease());
			Assert.AreEqual(1, player.GetResources());

			manage.EndTurn(player);

			var deploy = new[] {
				manage.Deploy(Light[0], field.GetCell(4, 1)),
				manage.Deploy(Light[1], field.GetCell(3, 1)),
				manage.Deploy(Light[2], field.GetCell(3, 2)),
			};

			Assert.IsTrue(deploy[0].IsValid());
			Assert.IsTrue(deploy[1].IsValid());
			Assert.IsFalse(deploy[2].IsValid());

			Assert.AreEqual(Status.NotEnoughResources, deploy[2].GetStatus());

			Assert.AreEqual(field.GetCell(4, 1), Light[0].GetFieldLocation().GetCell());
			Assert.AreEqual(field.GetCell(3, 1), Light[1].GetFieldLocation().GetCell());

			Assert.IsTrue(Light[0].GetLocation().IsBattlefield());
			Assert.IsTrue(Light[1].GetLocation().IsBattlefield());
			Assert.IsTrue(Light[2].GetLocation().IsReserve());

			manage.EndTurn(enemy);

			HeavyDeploy = manage.Deploy(Heavy, field.GetCell(1, 0));
			Assert.IsTrue(HeavyDeploy.IsValid());
			Assert.IsTrue(Heavy.GetLocation().IsBattlefield());
			Assert.AreEqual(field.GetCell(1, 0), Heavy.GetFieldLocation().GetCell());


		}
	}
}