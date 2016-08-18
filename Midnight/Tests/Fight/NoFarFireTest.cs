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

			var Medium = engine.Chiefs[0].Cards.Factory.Create<TankMedium>();
			var Heavy  = engine.Chiefs[1].Cards.Factory.Create<TankHeavy>();

			manage.Position(Medium, engine.Field.GetCell(0, 1));
			manage.Position(Heavy , engine.Field.GetCell(4, 1));

			var fight = manage.Fight(Medium, Heavy);

			Assert.AreEqual(Status.TargetIsTooFar, fight.GetStatus());
			Assert.AreEqual(0, Medium.GetDamage());
			Assert.AreEqual(0, Heavy .GetDamage());
		}
	}
}
