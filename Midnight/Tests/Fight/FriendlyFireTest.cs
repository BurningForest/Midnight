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

			var Medium = engine.Chiefs[0].Cards.Factory.Create<TankMedium>();
			var Light = engine.Chiefs[0].Cards.Factory.Create<TankLight>();
			
			manage.Position(Light, engine.Field.GetCell(2, 1));
			manage.Position(Medium, engine.Field.GetCell(3, 1));
			
			var fight = manage.Fight(Light, Medium);

			Assert.AreEqual(Status.TargetIsFriendly, fight.GetStatus());
			Assert.AreEqual(0, Light.GetDamage());
			Assert.AreEqual(0, Medium.GetDamage());
		}
	}
}
