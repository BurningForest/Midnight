using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;
using Sun.CardProtos.Enums;

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

			var guards = player.Cards.Factory.CreateDefaultHq(HqGuards.proto);
			var artill = (Platoon) player.Cards.Factory.Create(PlatoonEnforceArtillery.proto);
			var scout1 = (Platoon) player.Cards.Factory.Create(PlatoonEnforceScout.proto);
			var scout2 = (Platoon) player.Cards.Factory.Create(PlatoonEnforceScout.proto);

			var consol = enemy.Cards.Factory.CreateDefaultHq(HqConsol.proto);

			manage.Draw(player, 3);
			manage.StartGame(player);

			Assert.IsTrue(manage.Deploy(artill).IsValid());

			Assert.AreSame(artill, player.Cards.GetPlatoonBySubtype(Subtype.Artillery));
			Utils.ArrayAreEqual(player.Cards.GetOrderedPlatoons(), new[]{ artill });

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
