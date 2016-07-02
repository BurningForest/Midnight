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
			
			var Medium1 = engine.chiefs[0].cards.factory.Create<TankMedium>();
			var Medium2 = engine.chiefs[0].cards.factory.Create<TankMedium>();
			var Heavy   = engine.chiefs[1].cards.factory.Create<TankHeavy>();

			manage.Position(Medium1, engine.field.GetCell(0, 0));
			manage.Position(Heavy, engine.field.GetCell(0, 1));
			manage.Position(Medium2, engine.field.GetCell(0, 2));
			
			manage.Fight(Medium1, Heavy);
			manage.Fight(Medium2, Heavy);

			Assert.AreEqual(3, Medium1.GetDamage());
			Assert.AreEqual(0, Medium2.GetDamage());
			Assert.AreEqual(4, Heavy.GetDamage());

			manage.EndTurn(engine.chiefs[0]);

			manage.Fight(Heavy, Medium2);
			Assert.AreEqual(3, Medium2.GetDamage());
			Assert.AreEqual(6, Heavy.GetDamage());

			manage.EndTurn(engine.chiefs[1]);
			
			manage.Fight(Medium1, Heavy);
			Assert.AreEqual(3, Medium1.GetDamage());
			Assert.AreEqual(8, Heavy.GetDamage());

			manage.Fight(Medium2, Heavy);
			Assert.AreEqual(3, Medium2.GetDamage());
			Assert.IsTrue(Heavy.IsDead());
		}
	}
}
