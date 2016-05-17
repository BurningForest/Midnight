using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Headquarters
{
	[TestClass]
	public class MobileHqTest
	{
		[TestMethod]
		public void MobileHq ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			engine.triggers.Register<TurnAddResources>();

			var field  = engine.field;
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];
			
			var mobile = player.cards.factory.CreateDefaultHq<HqMobile>();
			var light  = player.cards.factory.Create<TankLight>();
			var spatg  = player.cards.factory.Create<TankSpatg>();

			var strike = enemy.cards.factory.CreateDefaultHq<HqStrike>();
			var heavy  = enemy.cards.factory.Create<TankHeavy>();

			manage.Draw(light);
			manage.Draw(spatg);
			manage.Position(heavy, field.GetCell(2, 0));

			manage.StartGame(player);
			
			Assert.AreEqual(8, player.GetTotalIncrease());
			Assert.AreEqual(8, player.GetResources());

			Utils.ArrayAreEqual(player.GetFootholdCells(), new[]{
				field.GetCell(1, 0),
				field.GetCell(1, 1),
				field.GetCell(0, 1)
			});

			Assert.AreEqual(Status.TargetIsTooFar, manage.Fight(mobile, strike).GetStatus());
			Assert.IsTrue(manage.Deploy(light, field.GetCell(0, 1)).IsValid());
			Assert.IsTrue(manage.Move(mobile, field.GetCell(1, 0)).IsValid());
			Assert.IsTrue(manage.Deploy(spatg, field.GetCell(0, 0)).IsValid());

			Utils.ArrayAreEqual(player.GetFootholdCells(), new[]{
				field.GetCell(0, 0),
				field.GetCell(0, 1),
				field.GetCell(1, 1),
				field.GetCell(2, 1),
				field.GetCell(2, 0)
			});
			manage.EndTurn(player);
			
			manage.Fight(heavy, mobile);
			Assert.AreEqual(3, heavy.GetDamage());
			Assert.AreEqual(3, mobile.GetDamage());

			manage.EndTurn(enemy);

			manage.Fight(mobile, heavy);
			Assert.AreEqual(6, heavy.GetDamage());
			Assert.AreEqual(3, mobile.GetDamage());

			manage.EndTurn(player);

			manage.Fight(heavy, mobile);
			Assert.AreEqual(6, heavy.GetDamage());
			Assert.AreEqual(6, mobile.GetDamage());

		}
	}
}
