using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Tests.Instances;
using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Core;
using Midnight.Engine.Abilities.Positioning;
using Midnight.Engine.Actions;
using Midnight.Engine.ActionManager.Events;
using Midnight.Engine.Emitter;

namespace Midnight.Tests.Positioning
{
	[TestClass]
	public class MovementTest
	{
		[TestMethod]
		public void Movement ()
		{
			Engine.Engine engine = new Engine.Engine();
			var field  = engine.field;
            var player = engine.chiefs[0];
            var enemy  = engine.chiefs[1];

            var light  = player.cardFactory.Create<LightTank>();
			var medium = player.cardFactory.Create<MediumTank>();
			var heavy  = player.cardFactory.Create<HeavyTank>();
			var spg    = player.cardFactory.Create<SpgTank>();

			var manage = new Manage(engine.actions);

            light.ToReserve();
            medium.ToReserve();
            heavy.ToReserve();
            spg.ToReserve();

			manage.StartGame(player);

			// Light
			manage.Deploy(light, field.GetCell(0, 0));
			var firstLightMove = manage.Move(light, field.GetCell(1, 0));
			Assert.IsTrue(firstLightMove.IsValid());
			Assert.IsTrue(light.IsAtBattlefield());
			Assert.AreEqual(field.GetCell(1, 0), light.GetCell());

			var secondLightMove = manage.Move(light, field.GetCell(2, 0));
			Assert.IsFalse(secondLightMove.IsValid());
			Assert.AreEqual(field.GetCell(1, 0), light.GetCell());

			// Medium
			manage.Deploy(medium, field.GetCell(0, 1));
			var mediumMove = manage.Move(medium, field.GetCell(1, 1));
			Assert.IsFalse(mediumMove.IsValid());
			Assert.AreEqual(field.GetCell(0, 1), medium.GetCell());

			// Heavy
			manage.Deploy(heavy, field.GetCell(0, 2));
			var heavyMove = manage.Move(heavy, field.GetCell(1, 2));
			Assert.IsFalse(heavyMove.IsValid());
			Assert.AreEqual(field.GetCell(0, 2), heavy.GetCell());

			// Move without deploy
			var spgMove = manage.Move(spg, field.GetCell(0, 0));
			Assert.IsFalse(spgMove.IsValid());
			Assert.IsTrue(spg.IsAtReserve());

			manage.EndTurn(player);
            manage.EndTurn(enemy);

            // Light can jump
            var lightJump = manage.Move(light, field.GetCell(3, 0));
			Assert.IsTrue(lightJump.IsValid());
			Assert.AreEqual(field.GetCell(3, 0), light.GetCell());

			// medium diagonal
			var mediumDiagonalMove = manage.Move(medium, field.GetCell(1, 0));
			Assert.AreEqual(field.GetCell(1, 0), medium.GetCell());

			// heavy move
			var nextHeavyMove = manage.Move(heavy, field.GetCell(1, 2));
			Assert.IsTrue(nextHeavyMove.IsValid());
			Assert.AreEqual(field.GetCell(1, 2), heavy.GetCell());

		}
	}
}
