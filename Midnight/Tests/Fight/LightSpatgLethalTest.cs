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

			var Light = engine.Chiefs[0].Cards.Factory.Create<TankLight>();
			var Spatg = engine.Chiefs[1].Cards.Factory.Create<TankSpatg>();

			manage.Position(Light, engine.Field.GetCell(1, 1));
			manage.Position(Spatg, engine.Field.GetCell(2, 1));

			manage.Fight(Light, Spatg);

			Assert.AreEqual(0, Spatg.GetDamage());
			Assert.IsTrue(Light.IsDead());
		}
	}
}
