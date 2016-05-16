using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class MediumSpgDestroyTest
	{
		[TestMethod]
		public void MediumSpgDestroy ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var medium1 = engine.chiefs[0].cardFactory.Create<MediumTank>();
			var medium2 = engine.chiefs[0].cardFactory.Create<MediumTank>();
			var spg = engine.chiefs[1].cardFactory.Create<SpgTank>();

			manage.Position(medium1, engine.field.GetCell(2, 1));
			manage.Position(spg    , engine.field.GetCell(3, 1));
			manage.Position(medium2, engine.field.GetCell(4, 1));

			manage.Fight(medium1, spg);

			Assert.AreEqual(0, medium1.GetDamage());
			Assert.AreEqual(2, spg.GetDamage());

			var fight = manage.Fight(medium1, spg);

			Assert.AreEqual(Status.AbilityIsUsed, fight.GetStatus());
			Assert.AreEqual(2, spg.GetDamage());

			manage.Fight(medium2, spg);
			Assert.AreEqual(0, medium2.GetDamage());
			Assert.IsTrue(spg.IsDead());
		}
	}
}
