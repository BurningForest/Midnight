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

			engine.Triggers.Register<TurnAddResources>();

			var field  = engine.Field;
			var player = engine.Chiefs[0];
			var enemy  = engine.Chiefs[1];
			
			var mobile = player.Cards.Factory.CreateDefaultHq<HqMobile>();
			var Light  = player.Cards.Factory.Create<TankLight>();
			var Spatg  = player.Cards.Factory.Create<TankSpatg>();

			var strike = enemy.Cards.Factory.CreateDefaultHq<HqStrike>();
			var Heavy  = enemy.Cards.Factory.Create<TankHeavy>();

			manage.Draw(Light);
			manage.Draw(Spatg);
			manage.Position(Heavy, field.GetCell(2, 0));

			manage.StartGame(player);
			
			Assert.AreEqual(8, player.GetTotalIncrease());
			Assert.AreEqual(8, player.GetResources());

			Utils.ArrayAreEqual(player.GetFootholdCells(), new[]{
				field.GetCell(1, 0),
				field.GetCell(1, 1),
				field.GetCell(0, 1)
			});

			Assert.AreEqual(Status.TargetIsTooFar, manage.Fight(mobile, strike).GetStatus());
			Assert.IsTrue(manage.Deploy(Light, field.GetCell(0, 1)).IsValid());
			Assert.IsTrue(manage.Move(mobile, field.GetCell(1, 0)).IsValid());
			Assert.IsTrue(manage.Deploy(Spatg, field.GetCell(0, 0)).IsValid());

			Utils.ArrayAreEqual(player.GetFootholdCells(), new[]{
				field.GetCell(0, 0),
				field.GetCell(0, 1),
				field.GetCell(1, 1),
				field.GetCell(2, 1),
				field.GetCell(2, 0)
			});
			manage.EndTurn(player);
			
			manage.Fight(Heavy, mobile);
			Assert.AreEqual(3, Heavy.GetDamage());
			Assert.AreEqual(3, mobile.GetDamage());

			manage.EndTurn(enemy);

			manage.Fight(mobile, Heavy);
			Assert.AreEqual(6, Heavy.GetDamage());
			Assert.AreEqual(3, mobile.GetDamage());

			manage.EndTurn(player);

			manage.Fight(Heavy, mobile);
			Assert.AreEqual(6, Heavy.GetDamage());
			Assert.AreEqual(6, mobile.GetDamage());

		}
	}
}
