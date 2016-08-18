using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Actions;
using Midnight.Core;
using Midnight.Utils;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class SurrenderTest
	{

		[TestMethod]
		public void PrSurrenderediction ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			player.io.Surrender();

			Assert.AreNotEqual(null, engine.final);
			Assert.AreEqual(Final.Trigger.Surrender, engine.final.trigger);
			Assert.AreSame(enemy, engine.final.Winner);
		}
	}
}
