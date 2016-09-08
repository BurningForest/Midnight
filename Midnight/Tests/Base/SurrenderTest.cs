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

			var player = engine.Chiefs[0];
			var enemy  = engine.Chiefs[1];

			player.Io.Surrender();

			Assert.AreNotEqual(null, engine.Final);
			Assert.AreEqual(Final.Trigger.Surrender, engine.Final.trigger);
			Assert.AreSame(enemy, engine.Final.Winner);
		}
	}
}
