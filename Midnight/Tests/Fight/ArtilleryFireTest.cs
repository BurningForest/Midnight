using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

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

			var Spg = engine.chiefs[0].cards.factory.Create<TankSpg>();
			var Light = engine.chiefs[0].cards.factory.Create<TankLight>();
			var Medium = engine.chiefs[1].cards.factory.Create<TankMedium>();

			manage.Position(Spg, engine.field.GetCell(0, 1));
			manage.Position(Light, engine.field.GetCell(2, 1));
			manage.Position(Medium, engine.field.GetCell(4, 1));
			
			var fight = manage.Fight(Spg, Medium);
			Assert.AreEqual(Status.TargetIsNotSpotted, fight.GetStatus());
			Assert.AreEqual(0, Medium.GetDamage());

			manage.Move(Light, engine.field.GetCell(3, 1));
			manage.Fight(Spg, Medium);

			Assert.AreEqual(0, Spg.GetDamage());
			Assert.AreEqual(1, Medium.GetDamage());

			engine.chiefs[0].io.EndTurn();
			engine.chiefs[1].io.EndTurn();
			
			manage.Move(Light, engine.field.GetCell(2, 1));
			Assert.AreEqual(Status.TargetIsNotSpotted, manage.Fight(Spg, Medium).GetStatus());
			Assert.AreEqual(1, Medium.GetDamage());

		}
	}
}
