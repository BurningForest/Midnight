using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Abilities.Passive;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Instances.Germany.Orders;
using Midnight.Instances.Germany.Vehicles;
using Midnight.Instances.Usa.Vehicles;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Vehicles
{
	[TestClass]
	public class M2LightTest
	{


		[TestMethod]
		public void InUsa ()
		{
			CheckSupply<HqGuards>(Status.TargetIsUnderCamouflage);
		}

		[TestMethod]
		public void InGermany ()
		{
			CheckSupply<HqStrike>(Status.Success);
		}

		private void CheckSupply<TCard> (Status attackStatus)
			where TCard : Hq, new()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var field = engine.field;
			var player = engine.chiefs[0];
			var enemy = engine.chiefs[1];

			manage.SetResources(player, 50);

			var myHq = player.cards.factory.CreateDefaultHq<TCard>();
			var m2lt = player.cards.factory.Create<M2Light>();

			var hisHq = enemy.cards.factory.CreateDefaultHq<HqStrike>();
			var Spg = enemy.cards.factory.Create<TankSpg>();

			manage.Position(m2lt, field.GetCell(1, 1));
			manage.Position(Spg, field.GetCell(2, 1));

			enemy.io.StartGame();

			Assert.AreEqual(attackStatus, enemy.io.Attack(new Io.Target() {
				SourceId = Spg.Id,
				TargetId = m2lt.Id,
			}));
		}

	}
}
