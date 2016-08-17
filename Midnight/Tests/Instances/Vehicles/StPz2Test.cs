using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Abilities.Passive;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Instances.Germany.Orders;
using Midnight.Instances.Germany.Vehicles;
using Midnight.Tests.TestInstances;
using Midnight.Utils;

namespace Midnight.Tests.Instances.Vehicles
{
	[TestClass]
	public class StPz2Test
	{

		[TestMethod]
		public void InGermany ()
		{
			CheckSupply<HqStrike>(Location.Reserve);
		}

		[TestMethod]
		public void InUsa ()
		{
			CheckSupply<HqGuards>(Location.Deck);
		}

		private void CheckSupply<TCard> (Location HeavyLocation)
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
			var stPz2 = player.cards.factory.Create<StPz2>();
			var Heavy = player.cards.factory.Create<TankHeavy>();

			var hisHq = enemy.cards.factory.CreateDefaultHq<HqStrike>();
			var Spatg = enemy.cards.factory.Create<TankSpatg>();

			manage.Draw(stPz2);

			player.io.StartGame();

			Assert.AreEqual(Location.Deck, Heavy.GetLocation().GetCurrent());

			Assert.AreEqual(Status.Success, player.io.Deploy(new Io.Position
			{
				CardId = stPz2.id,
				X = 1,
				Y = 1
			}));
			
			Assert.AreEqual(HeavyLocation, Heavy.GetLocation().GetCurrent());
			Assert.AreEqual(Location.Deck, Spatg.GetLocation().GetCurrent());

			Assert.AreEqual(Status.Success, player.io.Attack(new Io.Target
			{
				SourceId = stPz2.id,
				TargetId = hisHq.id
			}));

			Assert.AreEqual(stPz2.GetPower(), hisHq.GetDamage());
		}

	}
}
