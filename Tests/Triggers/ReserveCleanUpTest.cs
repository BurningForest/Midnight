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
			
			engine.triggers.Register<ReserveCleanUp>();

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			for (int i = 0; i < 10; i++) {
				player.cards.factory.Create<TankLight>();
				player.cards.factory.Create<TankHeavy>();
				player.cards.factory.Create<TankSpatg>();
			}

			manage.Draw(player, 6);

			manage.StartGame(player);

			Assert.AreEqual(6, Count(player, Location.reserve));

			manage.EndTurn(player);
			manage.EndTurn(enemy);

			Assert.AreEqual(0, Count(player, Location.graveyard));
			Assert.AreEqual(6, Count(player, Location.reserve));

			manage.Draw(player, 1);
			
			Assert.AreEqual(0, Count(player, Location.graveyard));
			Assert.AreEqual(7, Count(player, Location.reserve));

			manage.EndTurn(player);
			
			Assert.AreEqual(1, Count(player, Location.graveyard));
			Assert.AreEqual(6, Count(player, Location.reserve));

			manage.Draw(player, 1);
			
			Assert.AreEqual(1, Count(player, Location.graveyard));
			Assert.AreEqual(7, Count(player, Location.reserve));

			manage.EndTurn(enemy);
			
			Assert.AreEqual(1, Count(player, Location.graveyard));
			Assert.AreEqual(7, Count(player, Location.reserve));

			manage.Draw(player, 2);
			
			Assert.AreEqual(1, Count(player, Location.graveyard));
			Assert.AreEqual(9, Count(player, Location.reserve));

			manage.EndTurn(player);
			
			Assert.AreEqual(4, Count(player, Location.graveyard));
			Assert.AreEqual(6, Count(player, Location.reserve));

		}

		private int Count (Chief chief, Location location)
		{
			return chief.cards.FromLocation(location).Count;
		}
	}
}
