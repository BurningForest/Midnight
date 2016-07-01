using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;
using System;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class NoFarFireTest
	{
		[TestMethod]
		public void NoFarFire ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var medium = engine.chiefs[0].cards.factory.Create<TankMedium>();
			var heavy  = engine.chiefs[1].cards.factory.Create<TankHeavy>();

			manage.Position(medium, engine.field.GetCell(0, 1));
			manage.Position(heavy , engine.field.GetCell(4, 1));

			var fight = manage.Fight(medium, heavy);

			Assert.AreEqual(Status.TargetIsTooFar, fight.GetStatus());
			Assert.AreEqual(0, medium.GetDamage());
			Assert.AreEqual(0, heavy .GetDamage());
		}
	}
}
