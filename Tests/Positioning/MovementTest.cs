using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Tests.Instances;
using Midnight.Core;
using Midnight.Triggers;

namespace Midnight.Tests.Positioning
{
	[TestClass]
	public class MovementTest
	{
		[TestMethod]
		public void Movement ()
		{
			Engine engine = new Engine();
			var logger = new Logger(engine);

			new TurnAddResources(engine);

			var field = engine.field;
			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			player.SetOwnIncrease(50);
			enemy.SetOwnIncrease(50);

			var light = player.cardFactory.Create<LightTank>();
			var medium = player.cardFactory.Create<MediumTank>();
			var heavy = player.cardFactory.Create<HeavyTank>();
			var spg = player.cardFactory.Create<SpgTank>();

			var manage = new Manage(engine);

			light.GetLocation().ToReserve();
			medium.GetLocation().ToReserve();
			heavy.GetLocation().ToReserve();
			spg.GetLocation().ToReserve();

			manage.StartGame(player);

			// Light
			manage.Deploy(light, field.GetCell(0, 0));
			var firstLightMove = manage.Move(light, field.GetCell(1, 0));
			Assert.IsTrue(firstLightMove.IsValid());
			Assert.IsTrue(light.GetLocation().IsBattlefield());
			Assert.AreEqual(field.GetCell(1, 0), light.GetFieldLocation().GetCell());

			var secondLightMove = manage.Move(light, field.GetCell(2, 0));
			Assert.IsFalse(secondLightMove.IsValid());
			Assert.AreEqual(field.GetCell(1, 0), light.GetFieldLocation().GetCell());

			// Medium
			manage.Deploy(medium, field.GetCell(0, 1));
			var mediumMove = manage.Move(medium, field.GetCell(1, 1));
			Assert.IsFalse(mediumMove.IsValid());
			Assert.AreEqual(Status.PointsAreUsed, mediumMove.GetStatus());
			Assert.AreEqual(field.GetCell(0, 1), medium.GetFieldLocation().GetCell());

			// Heavy
			manage.Deploy(heavy, field.GetCell(0, 2));
			var heavyMove = manage.Move(heavy, field.GetCell(1, 2));
			Assert.IsFalse(heavyMove.IsValid());
			Assert.AreEqual(Status.PointsAreUsed, heavyMove.GetStatus());
			Assert.AreEqual(field.GetCell(0, 2), heavy.GetFieldLocation().GetCell());

			// Move without deploy
			var spgMove = manage.Move(spg, field.GetCell(0, 0));
			Assert.IsFalse(spgMove.IsValid());
			Assert.AreEqual(Status.NotAtBattlefield, spgMove.GetStatus());
			Assert.IsTrue(spg.GetLocation().IsReserve());

			manage.EndTurn(player);
			manage.EndTurn(enemy);

			// Light can jump
			var lightJump = manage.Move(light, field.GetCell(3, 0));
			Assert.IsTrue(lightJump.IsValid());
			Assert.AreEqual(field.GetCell(3, 0), light.GetFieldLocation().GetCell());

			// medium diagonal
			var mediumDiagonalMove = manage.Move(medium, field.GetCell(1, 0));
			Assert.AreEqual(field.GetCell(1, 0), medium.GetFieldLocation().GetCell());

			// heavy move
			var nextHeavyMove = manage.Move(heavy, field.GetCell(1, 2));
			Assert.IsTrue(nextHeavyMove.IsValid());
			Assert.AreEqual(field.GetCell(1, 2), heavy.GetFieldLocation().GetCell());

		}
	}
}
