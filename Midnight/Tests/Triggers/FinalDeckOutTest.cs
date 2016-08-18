using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;
using Midnight.Actions;

namespace Midnight.Tests.Triggers
{
	[TestClass]
	public class FinalDeckOutTest
	{
		[TestMethod]
		public void FinalDeckOut ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var final = new FinalListener(engine);

			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			engine.triggers.Register<CardAutoDraw>();
			engine.triggers.Register<FinalDeckOut>();
			engine.triggers.Register<FinalHqDeath>(player);
			engine.triggers.Register<FinalHqDeath>(enemy);

			for (int i = 0; i < 10; i++) {
				player.cards.factory.Create<TankLight>();
				enemy .cards.factory.Create<TankLight>();
			}

			manage.Draw(player, 8);
			manage.Draw(enemy , 6);

			manage.StartGame(player);

			manage.EndTurn(player);
			manage.EndTurn(enemy);  // 1 card in player deck

			manage.EndTurn(player);
			manage.EndTurn(enemy);

			Assert.AreEqual(null, final.action);
			Assert.AreEqual(0, player.cards.CountLocation(Location.Deck));

			manage.EndTurn(player);

			Assert.AreEqual(null, final.action);
			Assert.AreEqual(0, player.cards.CountLocation(Location.Deck));

			manage.EndTurn(enemy);

			Assert.AreNotEqual(null, final.action);
			Assert.AreEqual(1, final.count);
			Assert.AreEqual(Final.Trigger.DeckOut, final.action.trigger);
			Assert.AreSame(enemy, final.action.Winner);
		}
	}
}
