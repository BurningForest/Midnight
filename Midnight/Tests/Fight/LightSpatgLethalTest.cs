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

			var Light = engine.chiefs[0].cards.factory.Create<TankLight>();
			var Spatg = engine.chiefs[1].cards.factory.Create<TankSpatg>();

			manage.Position(Light, engine.field.GetCell(1, 1));
			manage.Position(Spatg, engine.field.GetCell(2, 1));

			manage.Fight(Light, Spatg);

			Assert.AreEqual(0, Spatg.GetDamage());
			Assert.IsTrue(Light.IsDead());
		}
	}
}
