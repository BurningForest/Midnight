using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class DoubleSuicideTest
	{
		[TestMethod]
		public void DoubleSuicide ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];
			
			var Spatg1 = player.cards.factory.Create<TankSpatg>();
			var Spatg2 = enemy .cards.factory.Create<TankSpatg>();

			manage.Position(Spatg1, engine.field.GetCell(0, 1));
			manage.Position(Spatg2, engine.field.GetCell(1, 1));

			manage.StartGame();

			player.io.Attack(new Io.Target() {
				sourceId = Spatg1.id,
				targetId = Spatg2.id
			});

			Assert.IsTrue(Spatg1.IsDead());
			Assert.IsTrue(Spatg2.IsDead());
		}
	}
}
