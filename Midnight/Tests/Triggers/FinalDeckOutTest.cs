﻿using System;
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

			var player = engine.Chiefs[0];
			var enemy = engine.Chiefs[1];

			engine.Triggers.Register<CardAutoDraw>();
			engine.Triggers.Register<FinalDeckOut>();
			engine.Triggers.Register<FinalHqDeath>(player);
			engine.Triggers.Register<FinalHqDeath>(enemy);

			for (int i = 0; i < 10; i++) {
				player.Cards.Factory.Create<TankLight>();
				enemy .Cards.Factory.Create<TankLight>();
			}

			manage.Draw(player, 8);
			manage.Draw(enemy , 6);

			manage.StartGame(player);

			manage.EndTurn(player);
			manage.EndTurn(enemy);  // 1 card in player deck

			manage.EndTurn(player);
			manage.EndTurn(enemy);

			Assert.AreEqual(null, final.action);
			Assert.AreEqual(0, player.Cards.CountLocation(Location.Deck));

			manage.EndTurn(player);

			Assert.AreEqual(null, final.action);
			Assert.AreEqual(0, player.Cards.CountLocation(Location.Deck));

			manage.EndTurn(enemy);

			Assert.AreNotEqual(null, final.action);
			Assert.AreEqual(1, final.count);
			Assert.AreEqual(Final.Trigger.DeckOut, final.action.trigger);
			Assert.AreSame(enemy, final.action.Winner);
		}
	}
}
