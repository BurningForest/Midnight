using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class ArtilleryFireTest
	{
		[TestMethod]
		public void ArtilleryFire ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var spg = engine.chiefs[0].cardFactory.Create<SpgTank>();
			var light = engine.chiefs[0].cardFactory.Create<LightTank>();
			var medium = engine.chiefs[1].cardFactory.Create<MediumTank>();

			manage.Position(spg, engine.field.GetCell(0, 1));
			manage.Position(light, engine.field.GetCell(2, 1));
			manage.Position(medium, engine.field.GetCell(4, 1));

			// Spotted
			// var fight = manage.Fight(spg, medium);
			// Assert.AreEqual(0, medium.GetDamage());

			manage.Move(light, engine.field.GetCell(3, 1));
			manage.Fight(spg, medium);

			Assert.AreEqual(0, spg.GetDamage());
			Assert.AreEqual(1, medium.GetDamage());
		}
	}
}
