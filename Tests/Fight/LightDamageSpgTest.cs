using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class LightDamageSpgTest
	{
		[TestMethod]
		public void LightDamageSpg ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var light = engine.chiefs[0].cardFactory.Create<LightTank>();
			var spg   = engine.chiefs[1].cardFactory.Create<SpgTank>();

			manage.Position(light, engine.field.GetCell(1, 1));
			manage.Position(spg, engine.field.GetCell(2, 1));

			manage.Fight(light, spg);

			Assert.AreEqual(0, light.GetDamage());
			Assert.AreEqual(1, spg.GetDamage());
		}
	}
}
