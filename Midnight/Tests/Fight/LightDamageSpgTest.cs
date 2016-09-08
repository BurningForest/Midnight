using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

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

			var Light = engine.Chiefs[0].Cards.Factory.Create<TankLight>();
			var Spg   = engine.Chiefs[1].Cards.Factory.Create<TankSpg>();

			manage.Position(Light, engine.Field.GetCell(1, 1));
			manage.Position(Spg, engine.Field.GetCell(2, 1));

			manage.Fight(Light, Spg);

			Assert.AreEqual(0, Light.GetDamage());
			Assert.AreEqual(1, Spg.GetDamage());
		}
	}
}
