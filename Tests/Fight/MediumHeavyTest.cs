using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Engine.Core;
using Midnight.Tests.Instances;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class MediumHeavyTest
	{
		[TestMethod]
		public void MediumHeavy ()
		{
			var engine = new Engine.Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var medium = engine.chiefs[0].cardFactory.Create<MediumTank>();
			var heavy  = engine.chiefs[1].cardFactory.Create<HeavyTank>();

			manage.Position(medium, engine.field.GetCell(1, 1));
			manage.Position(heavy , engine.field.GetCell(2, 1));

			manage.Fight(medium, heavy);

			Assert.AreEqual(3, medium.GetDamage());
			Assert.AreEqual(2, heavy.GetDamage());
		}
	}
}
