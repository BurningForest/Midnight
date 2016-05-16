using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Positioning
{
	[TestClass]
	public class DeploymentTest
	{
		[TestMethod]
		public void Deployment ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			new TurnAddResources(engine);

			var field  = engine.field;
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			player.cards.factory.AddDefaultHq<HqConsol>();

		}
	}
}
