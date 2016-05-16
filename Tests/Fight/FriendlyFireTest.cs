using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class FriendyFireTest
	{
		[TestMethod]
		public void FriendlyFire ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var medium = engine.chiefs[0].cards.factory.Create<MediumTank>();
			var light = engine.chiefs[0].cards.factory.Create<LightTank>();
			
			manage.Position(light, engine.field.GetCell(2, 1));
			manage.Position(medium, engine.field.GetCell(3, 1));
			
			var fight = manage.Fight(light, medium);

			Assert.AreEqual(Status.TargetIsFriendly, fight.GetStatus());
			Assert.AreEqual(0, light.GetDamage());
			Assert.AreEqual(0, medium.GetDamage());
		}
	}
}
