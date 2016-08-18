using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Fight
{
	[TestClass]
	public class MediumHeavyTest
	{
		[TestMethod]
		public void MediumHeavy ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			manage.StartGame();

			var Medium = engine.chiefs[0].Cards.Factory.Create<TankMedium>();
			var Heavy  = engine.chiefs[1].Cards.Factory.Create<TankHeavy>();

			manage.Position(Medium, engine.field.GetCell(1, 1));
			manage.Position(Heavy , engine.field.GetCell(2, 1));

			manage.Fight(Medium, Heavy);

			Assert.AreEqual(3, Medium.GetDamage());
			Assert.AreEqual(2, Heavy.GetDamage());
		}
	}
}
