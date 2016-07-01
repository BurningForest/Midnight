using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class SeveralAttacksTest
	{
		[TestMethod]
		public void SeveralAttacks ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();
			
			var medium1 = engine.chiefs[0].cards.factory.Create<TankMedium>();
			var medium2 = engine.chiefs[0].cards.factory.Create<TankMedium>();
			var heavy   = engine.chiefs[1].cards.factory.Create<TankHeavy>();

			manage.Position(medium1, engine.field.GetCell(0, 0));
			manage.Position(heavy, engine.field.GetCell(0, 1));
			manage.Position(medium2, engine.field.GetCell(0, 2));
			
			manage.Fight(medium1, heavy);
			manage.Fight(medium2, heavy);

			Assert.AreEqual(3, medium1.GetDamage());
			Assert.AreEqual(0, medium2.GetDamage());
			Assert.AreEqual(4, heavy.GetDamage());

			manage.EndTurn(engine.chiefs[0]);

			manage.Fight(heavy, medium2);
			Assert.AreEqual(3, medium2.GetDamage());
			Assert.AreEqual(6, heavy.GetDamage());

			manage.EndTurn(engine.chiefs[1]);
			
			manage.Fight(medium1, heavy);
			Assert.AreEqual(3, medium1.GetDamage());
			Assert.AreEqual(8, heavy.GetDamage());

			manage.Fight(medium2, heavy);
			Assert.AreEqual(3, medium2.GetDamage());
			Assert.IsTrue(heavy.IsDead());
		}
	}
}
