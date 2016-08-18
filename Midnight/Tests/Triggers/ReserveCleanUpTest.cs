using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Triggers
{
	[TestClass]
	public class ReserveCleanUpTest
	{
		[TestMethod]
		public void ReserveCleanUp ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var cleanUp = engine.triggers.Register<ReserveCleanUp>();

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			for (int i = 0; i < 10; i++) {
				player.Cards.Factory.Create<TankLight>();
				player.Cards.Factory.Create<TankHeavy>();
				player.Cards.Factory.Create<TankSpatg>();
			}

			Assert.AreEqual(6, cleanUp.GetMax());
			cleanUp.SetMax(5);
			Assert.AreEqual(5, cleanUp.GetMax());
			cleanUp.SetMax(6);
			Assert.AreEqual(6, cleanUp.GetMax());

			manage.Draw(player, 6);

			manage.StartGame(player);

			Assert.AreEqual(6, player.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(player);
			manage.EndTurn(enemy);

			Assert.AreEqual(0, player.Cards.CountLocation(Location.Graveyard));
			Assert.AreEqual(6, player.Cards.CountLocation(Location.Reserve));

			manage.Draw(player);
			
			Assert.AreEqual(0, player.Cards.CountLocation(Location.Graveyard));
			Assert.AreEqual(7, player.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(player);
			
			Assert.AreEqual(1, player.Cards.CountLocation(Location.Graveyard));
			Assert.AreEqual(6, player.Cards.CountLocation(Location.Reserve));

			manage.Draw(player);
			
			Assert.AreEqual(1, player.Cards.CountLocation(Location.Graveyard));
			Assert.AreEqual(7, player.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(enemy);
			
			Assert.AreEqual(1, player.Cards.CountLocation(Location.Graveyard));
			Assert.AreEqual(7, player.Cards.CountLocation(Location.Reserve));

			manage.Draw(player, 2);
			
			Assert.AreEqual(1, player.Cards.CountLocation(Location.Graveyard));
			Assert.AreEqual(9, player.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(player);
			
			Assert.AreEqual(4, player.Cards.CountLocation(Location.Graveyard));
			Assert.AreEqual(6, player.Cards.CountLocation(Location.Reserve));

		}
	}
}
