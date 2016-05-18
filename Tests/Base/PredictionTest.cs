using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Instances.Germany.Orders;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class PredictionTest
	{

		[TestMethod]
		public void Prediction ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var field  = engine.field;
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];
			
			var strike = player.cards.factory.CreateDefaultHq<HqStrike>();
			var medium = player.cards.factory.Create<TankMedium>();
			var light  = player.cards.factory.Create<TankLight>();
			var order  = player.cards.factory.Create<EachBattle>();
			var platoon = player.cards.factory.Create<PlatoonEnforceArtillery>();

			var guards = enemy.cards.factory.CreateDefaultHq<HqGuards>();
			var heavy  = enemy.cards.factory.Create<TankHeavy>();

			manage.Position(heavy , field.GetCell(0, 1));
			manage.Position(medium, field.GetCell(0, 2));
			manage.Draw(player, 3);
			manage.SetResources(player, 50);

			manage.StartGame(enemy);
			manage.Fight(heavy, strike);

			Assert.AreEqual(3, strike.GetDamage());

			manage.EndTurn(enemy);

			var emulated = player.GetEmulated();

			emulated.Attack(
				new Io.Target() {
					sourceId = medium.id,
					targetId = heavy.id
				}
			);
			emulated.Order(
				new Io.Target() {
					sourceId = order.id,
					targetId = heavy.id
				}
			);

			Assert.AreEqual(
				Status.AbilityIsUsed,
				emulated.Attack(
					new Io.Target() {
						sourceId = medium.id,
						targetId = heavy.id
					}
				)
			);

			Assert.AreEqual(
				Status.NotAtReserve,
				emulated.Order(
					new Io.Target() {
						sourceId = order.id,
						targetId = heavy.id
					}
				)
			);

			var damages = emulated.GetDamagePredictions();
			Assert.AreEqual(2, damages.Count);

			Assert.AreEqual(damages[0].cardId, heavy.id);
			Assert.AreEqual(4, damages[0].value);

			Assert.AreEqual(damages[1].cardId, strike.id);
			Assert.AreEqual(-2, damages[1].value);

			Assert.AreEqual(0, heavy.GetDamage());
			Assert.AreEqual(3, strike.GetDamage());

			Assert.AreEqual(
				Status.Success,
				emulated.Deploy(new Io.Position() {
					cardId = light.id,
					x = 1,
					y = 0
				})
			);

			Assert.AreEqual(
				Status.Success,
				emulated.Move(new Io.Position() {
					cardId = light.id,
					x = 1,
					y = 1
				})
			);

			Assert.AreEqual(
				Status.Success,
				emulated.Deploy(new Io.SingleCard() {
					cardId = platoon.id
				})
			);
			Assert.AreEqual( Status.Success, emulated.EndTurn() );
		}
	}
}
