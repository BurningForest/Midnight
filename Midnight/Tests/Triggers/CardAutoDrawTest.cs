using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Triggers
{
	[TestClass]
	public class CardAutoDrawTest
	{
		[TestMethod]
		public void CardAutoDraw ()
		{
			Engine engine = new Engine();
			Logger logger = new Logger(engine);
			Manage manage = new Manage(engine);

			var autoDraw = engine.triggers.Register<CardAutoDraw>();
			
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			player.Cards.SetShuffleOff();
			
			var plCards = new FieldCard[] {
				player.Cards.Factory.Create<TankLight>(),
				player.Cards.Factory.Create<TankMedium>(),
				player.Cards.Factory.Create<TankHeavy>(),
				player.Cards.Factory.Create<TankSpg>()
			};

			var enCards = new FieldCard[] {
				enemy.Cards.Factory.Create<TankLight>(),
				enemy.Cards.Factory.Create<TankMedium>(),
				enemy.Cards.Factory.Create<TankHeavy>(),
				enemy.Cards.Factory.Create<TankSpatg>()
			};

			Assert.AreEqual(1, autoDraw.GetCount());
			autoDraw.SetCount(2);
			Assert.AreEqual(2, autoDraw.GetCount());
			autoDraw.SetCount(1);
			Assert.AreEqual(1, autoDraw.GetCount());
			
			manage.StartGame(enemy);

			Assert.AreEqual(0, player.Cards.CountLocation(Location.Reserve));
			Assert.AreEqual(0, enemy.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(enemy);

			Assert.AreEqual(1, player.Cards.CountLocation(Location.Reserve));
			Assert.AreEqual(0, enemy.Cards.CountLocation(Location.Reserve));
			Assert.IsTrue(plCards[0].GetLocation().IsReserve());

			manage.EndTurn(player);

			Assert.AreEqual(1, player.Cards.CountLocation(Location.Reserve));
			Assert.AreEqual(1, enemy.Cards.CountLocation(Location.Reserve));
			
			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Assert.AreEqual(2, player.Cards.CountLocation(Location.Reserve));
			Assert.AreEqual(2, enemy.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Assert.AreEqual(3, player.Cards.CountLocation(Location.Reserve));
			Assert.AreEqual(3, enemy.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Assert.AreEqual(4, player.Cards.CountLocation(Location.Reserve));
			Assert.AreEqual(4, enemy.Cards.CountLocation(Location.Reserve));

			manage.EndTurn(enemy);
			manage.EndTurn(player);
			manage.EndTurn(enemy);
			manage.EndTurn(player);
			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Utils.ArrayAreEqual(plCards, player.Cards.FromLocation(Location.Reserve));
			Utils.ArrayAreEqual(enCards, enemy.Cards.FromLocation(Location.Reserve));
		}
	}
}
