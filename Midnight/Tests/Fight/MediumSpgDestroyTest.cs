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

			var Medium1 = engine.chiefs[0].Cards.Factory.Create<TankMedium>();
			var Medium2 = engine.chiefs[0].Cards.Factory.Create<TankMedium>();
			var Spg     = engine.chiefs[1].Cards.Factory.Create<TankSpg>();

			manage.Position(Medium1, engine.field.GetCell(2, 1));
			manage.Position(Spg    , engine.field.GetCell(3, 1));
			manage.Position(Medium2, engine.field.GetCell(4, 1));

			manage.Fight(Medium1, Spg);

			Assert.AreEqual(0, Medium1.GetDamage());
			Assert.AreEqual(2, Spg.GetDamage());

			var fight = manage.Fight(Medium1, Spg);

			Assert.AreEqual(Status.AbilityIsUsed, fight.GetStatus());
			Assert.AreEqual(2, Spg.GetDamage());

			manage.Fight(Medium2, Spg);
			Assert.AreEqual(0, Medium2.GetDamage());
			Assert.IsTrue(Spg.IsDead());
		}
	}
}
