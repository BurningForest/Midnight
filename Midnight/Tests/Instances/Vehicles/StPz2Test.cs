﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

			var field = engine.Field;
			var player = engine.Chiefs[0];
			var enemy = engine.Chiefs[1];

			manage.SetResources(player, 50);

			var myHq = player.Cards.Factory.CreateDefaultHq<TCard>();
			var stPz2 = player.Cards.Factory.Create<StPz2>();
			var Heavy = player.Cards.Factory.Create<TankHeavy>();

			var hisHq = enemy.Cards.Factory.CreateDefaultHq<HqStrike>();
			var Spatg = enemy.Cards.Factory.Create<TankSpatg>();

			manage.Draw(stPz2);

			player.Io.StartGame();

			Assert.AreEqual(Location.Deck, Heavy.GetLocation().GetCurrent());

			Assert.AreEqual(Status.Success, player.Io.Deploy(new Io.Position
			{
				CardId = stPz2.Id,
				X = 1,
				Y = 1
			}));
			
			Assert.AreEqual(HeavyLocation, Heavy.GetLocation().GetCurrent());
			Assert.AreEqual(Location.Deck, Spatg.GetLocation().GetCurrent());

			Assert.AreEqual(Status.Success, player.Io.Attack(new Io.Target
			{
				SourceId = stPz2.Id,
				TargetId = hisHq.Id
			}));

			Assert.AreEqual(stPz2.GetPower(), hisHq.GetDamage());
		}

	}
}
