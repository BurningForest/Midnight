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

			var field  = engine.Field;
			var player = engine.Chiefs[0];
			var enemy  = engine.Chiefs[1];
			
			var strike = player.Cards.Factory.CreateDefaultHq<HqStrike>();
			var Medium = player.Cards.Factory.Create<TankMedium>();
			var Light  = player.Cards.Factory.Create<TankLight>();
			var Order  = player.Cards.Factory.Create<ParisGun>();
			var Platoon = player.Cards.Factory.Create<PlatoonEnforceArtillery>();

			var guards = enemy.Cards.Factory.CreateDefaultHq<HqGuards>();
			var Heavy  = enemy.Cards.Factory.Create<TankHeavy>();

			manage.Position(Heavy , field.GetCell(0, 1));
			manage.Position(Medium, field.GetCell(0, 2));
			manage.Draw(player, 3);
			manage.SetResources(player, 50);

			manage.StartGame(enemy);
			manage.Fight(Heavy, strike);

			Assert.AreEqual(3, strike.GetDamage());

			manage.EndTurn(enemy);

			var emulated = player.GetEmulated();

			emulated.Attack(
				new Io.Target() {
					SourceId = Medium.Id,
					TargetId = Heavy.Id
				}
			);
			emulated.Order(
				new Io.Target() {
					SourceId = Order.Id,
					TargetId = Heavy.Id
				}
			);

			Assert.AreEqual(
				Status.AbilityIsUsed,
				emulated.Attack(
					new Io.Target() {
						SourceId = Medium.Id,
						TargetId = Heavy.Id
					}
				)
			);

			Assert.AreEqual(
				Status.NotAtReserve,
				emulated.Order(
					new Io.Target() {
						SourceId = Order.Id,
						TargetId = Heavy.Id
					}
				)
			);

			var damages = emulated.GetDamagePredictions();
			Assert.AreEqual(2, damages.Count);

			Assert.AreEqual(damages[0].CardId, Heavy.Id);
			Assert.AreEqual(4, damages[0].Value);

			Assert.AreEqual(damages[1].CardId, strike.Id);
			Assert.AreEqual(-2, damages[1].Value);

			Assert.AreEqual(0, Heavy.GetDamage());
			Assert.AreEqual(3, strike.GetDamage());

			Assert.AreEqual(
				Status.Success,
				emulated.Deploy(new Io.Position
				{
					CardId = Light.Id,
					X = 1,
					Y = 0
				})
			);

			Assert.AreEqual(
				Status.Success,
				emulated.Move(new Io.Position
				{
					CardId = Light.Id,
					X = 1,
					Y = 1
				})
			);

			Assert.AreEqual(
				Status.Success,
				emulated.Deploy(new Io.SingleCard() {
					CardId = Platoon.Id
				})
			);
			Assert.AreEqual( Status.Success, emulated.EndTurn() );
		}
	}
}
