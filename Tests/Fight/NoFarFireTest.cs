using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Engine.Core;
using Midnight.Tests.Instances;
using System;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class NoFarFireTest
	{
		[TestMethod]
		public void NoFarFire ()
		{
			var engine = new Engine.Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var medium = engine.chiefs[0].cardFactory.Create<MediumTank>();
			var heavy  = engine.chiefs[1].cardFactory.Create<HeavyTank>();

			manage.Position(medium, engine.field.GetCell(0, 1));
			manage.Position(heavy , engine.field.GetCell(4, 1));

			var fight = manage.Fight(medium, heavy);

			Assert.AreEqual(Status.TargetIsTooFar, fight.GetStatus());
			Assert.AreEqual(0, medium.GetDamage());
			Assert.AreEqual(0, heavy .GetDamage());
		}
	}
}
