﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Headquarters
{
	[TestClass]
	public class PlatoonEnforceTest
	{
		[TestMethod]
		public void PlatoonEnforce ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			engine.triggers.Register<TurnAddResources>();

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			var guards = player.cards.factory.CreateDefaultHq(HqGuards.proto);
			var artill = (Platoon) player.cards.factory.Create(PlatoonEnforceArtillery.proto);
			var scout1 = (Platoon) player.cards.factory.Create(PlatoonEnforceScout.proto);
			var scout2 = (Platoon) player.cards.factory.Create(PlatoonEnforceScout.proto);

			var consol = enemy.cards.factory.CreateDefaultHq(HqConsol.proto);

			manage.Draw(player, 3);
			manage.StartGame(player);

			Assert.IsTrue(manage.Deploy(artill).IsValid());

			Assert.AreSame(artill, player.cards.GetPlatoonBySubtype(Subtype.artillery));
			Utils.ArrayAreEqual(player.cards.GetOrderedPlatoons(), new[]{ artill });

			Assert.IsTrue(manage.Fight(guards, consol).IsValid());
			Assert.AreEqual(1, artill.GetDamage());
			Assert.AreEqual(2, consol.GetDamage());

			manage.EndTurn(player);
			manage.EndTurn(enemy);

			Assert.IsTrue(manage.Deploy(scout1).IsValid());
			Assert.IsFalse(artill.IsDead());

			Assert.IsTrue(manage.Deploy(scout2).IsValid());
			Assert.IsTrue(scout1.IsDead());
			Assert.IsFalse(artill.IsDead());

			Assert.IsTrue(manage.Fight(guards, consol).IsValid());
			Assert.AreEqual(2, artill.GetDamage());
			Assert.AreEqual(2, scout2.GetDamage());
			Assert.AreEqual(6, consol.GetDamage());
		}
	}
}
