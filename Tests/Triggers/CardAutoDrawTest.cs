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

			engine.triggers.Register<CardAutoDraw>();
			
			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];

			player.cards.SetShuffleOff();

			var plCards = new FieldCard[] {
				player.cards.factory.Create<TankLight>(),
				player.cards.factory.Create<TankMedium>(),
				player.cards.factory.Create<TankHeavy>(),
				player.cards.factory.Create<TankSpg>()
			};

			var enCards = new FieldCard[] {
				enemy.cards.factory.Create<TankLight>(),
				enemy.cards.factory.Create<TankMedium>(),
				enemy.cards.factory.Create<TankHeavy>(),
				enemy.cards.factory.Create<TankSpatg>()
			};

			manage.StartGame(enemy);

			Assert.AreEqual(0, player.cards.CountLocation(Location.reserve));
			Assert.AreEqual(0, enemy.cards.CountLocation(Location.reserve));

			manage.EndTurn(enemy);

			Assert.AreEqual(1, player.cards.CountLocation(Location.reserve));
			Assert.AreEqual(0, enemy.cards.CountLocation(Location.reserve));
			Assert.IsTrue(plCards[0].GetLocation().IsReserve());

			manage.EndTurn(player);

			Assert.AreEqual(1, player.cards.CountLocation(Location.reserve));
			Assert.AreEqual(1, enemy.cards.CountLocation(Location.reserve));


			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Assert.AreEqual(2, player.cards.CountLocation(Location.reserve));
			Assert.AreEqual(2, enemy.cards.CountLocation(Location.reserve));

			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Assert.AreEqual(3, player.cards.CountLocation(Location.reserve));
			Assert.AreEqual(3, enemy.cards.CountLocation(Location.reserve));

			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Assert.AreEqual(4, player.cards.CountLocation(Location.reserve));
			Assert.AreEqual(4, enemy.cards.CountLocation(Location.reserve));

			manage.EndTurn(enemy);
			manage.EndTurn(player);
			manage.EndTurn(enemy);
			manage.EndTurn(player);
			manage.EndTurn(enemy);
			manage.EndTurn(player);

			Utils.ArrayAreEqual(plCards, player.cards.FromLocation(Location.reserve));
			Utils.ArrayAreEqual(enCards, enemy.cards.FromLocation(Location.reserve));
		}
	}
}
