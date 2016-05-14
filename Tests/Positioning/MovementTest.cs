using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Tests.Instances;
using Midnight.Engine.ChiefOperations;
using Midnight.Engine.Core;

namespace Midnight.Tests.Positioning
{
	[TestClass]
	public class MovementTest
	{
		//[TestMethod]
		public void Movement ()
		{
			Engine.Engine engine = new Engine.Engine();
			var field = engine.field;
			var chief = engine.chiefs[0];

			var light  = chief.cardFactory.Create<LightTank>();
			var medium = chief.cardFactory.Create<MediumTank>();
			var heavy  = chief.cardFactory.Create<HeavyTank>();
			var spg    = chief.cardFactory.Create<SpgTank>();

			var manage = new Manage(engine.actions);

			manage.StartGame(chief);

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

			manage.EndTurn(chief);

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
