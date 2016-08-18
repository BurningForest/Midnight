using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Headquarters
{
	[TestClass]
	public class PlatoonProtectTest
	{
		[TestMethod]
		public void PlatoonProtect ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			engine.Triggers.Register<TurnAddResources>();

			var player = engine.Chiefs[0];
			var enemy  = engine.Chiefs[1];
			var field  = engine.Field;

			var strike = player.Cards.Factory.CreateDefaultHq<HqStrike>(); // 3/20
			var Spg    = player.Cards.Factory.Create<TankBigSpg>(); // 8/4

			var consol = enemy.Cards.Factory.CreateDefaultHq<HqConsol>(); // 2/25
			var medic  = enemy.Cards.Factory.Create<PlatoonProtectMedic>(); // 2/7
			var intend = enemy.Cards.Factory.Create<PlatoonProtectIntendancy>(); // 3/3

			manage.Position(Spg, field.GetCell(4, 1));

			manage.StartGame(enemy);
			manage.Draw(enemy, 3);

			manage.Deploy(medic);
			manage.Fight(consol, strike);

			Assert.AreEqual(2, strike.GetDamage());

			manage.EndTurn(enemy);
			
			manage.Fight(strike, consol); // 3 damage
			Assert.AreEqual(2, medic.GetDamage()); // absorb 2 damage
			Assert.AreEqual(1, consol.GetDamage()); // 1 damage received

			manage.EndTurn(player);

			manage.Deploy(intend);

			manage.EndTurn(enemy);

			Assert.IsTrue(manage.Fight(strike, consol).IsValid()); // 3 damage
			Assert.AreEqual(4, medic.GetDamage());  // absorb 1 damage
			Assert.AreEqual(1, intend.GetDamage()); // absorb 2 damage
			Assert.AreEqual(1, consol.GetDamage()); // 0 damage received

			Assert.IsTrue(manage.Fight(Spg, consol).IsValid()); // 8 damage
			Assert.AreEqual(6, medic.GetDamage()); // absorb 2 damage
			Assert.IsTrue(intend.IsDead()); // absorb 3 damage
			Assert.AreEqual(4, consol.GetDamage()); // 3 damage received

		}
	}
}
