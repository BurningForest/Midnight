using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
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

			new TurnAddResources(engine);

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			var guards = player.cards.factory.CreateDefaultHq<HqGuards>();
			var artill = player.cards.factory.Create<PlatoonEnforceArtillery>();
			var scout  = player.cards.factory.Create<PlatoonEnforceScout>();

			var consol = enemy.cards.factory.CreateDefaultHq<HqConsol>();

			manage.Draw(player, 2);
			manage.StartGame(player);

			Assert.IsTrue(manage.Deploy(artill).IsValid());

			Assert.AreSame(artill, player.cards.GetPlatoonBySubtype(Subtype.artillery));
			Utils.ArrayAreEqual(player.cards.GetOrderedPlatoons(), new[]{ artill });

			Assert.IsTrue(manage.Fight(guards, consol).IsValid());
			Assert.AreEqual(1, artill.GetDamage());
			Assert.AreEqual(2, consol.GetDamage());

			manage.EndTurn(player);
			manage.EndTurn(enemy);
			
			Assert.IsTrue(manage.Deploy(scout).IsValid());
			Assert.IsFalse(artill.IsDead());

			Assert.IsTrue(manage.Fight(guards, consol).IsValid());
			Assert.AreEqual(2, artill.GetDamage());
			Assert.AreEqual(2, scout.GetDamage());
			Assert.AreEqual(6, consol.GetDamage());
		}
	}
}
