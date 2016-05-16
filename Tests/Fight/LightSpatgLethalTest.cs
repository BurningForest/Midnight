using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class LightSpatgLethalTest
	{
		[TestMethod]
		public void LightSpatgLethal ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var light = engine.chiefs[0].cardFactory.Create<LightTank>();
			var spatg = engine.chiefs[1].cardFactory.Create<SpatgTank>();

			manage.Position(light, engine.field.GetCell(1, 1));
			manage.Position(spatg, engine.field.GetCell(2, 1));

			manage.Fight(light, spatg);

			Assert.AreEqual(0, spatg.GetDamage());
			Assert.IsTrue(light.IsDead());
		}
	}
}
