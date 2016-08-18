using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Battlefield;
using Midnight.Cards;
using Midnight.Cards.Enums;
using Midnight.Cards.Types;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Midnight.Tests.Headquarters
{
	[TestClass]
	public class TypicalHqTest
	{
		[TestMethod]
		public void TypicalHq ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			engine.Triggers.Register<TurnAddResources>();

			var field  = engine.Field;
			var player = engine.Chiefs[0];
			var enemy  = engine.Chiefs[1];

			var strike = player.Cards.Factory.CreateDefaultHq<HqStrike>();
			var guards = enemy .Cards.Factory.CreateDefaultHq<HqGuards>();

			manage.StartGame(player);

			Assert.AreEqual(0, engine.Turn.GetNumber());

			Utils.ArrayAreEqual(player.GetFootholdCells(), new[] {
				field.GetCell(0, 1),
				field.GetCell(1, 1),
				field.GetCell(1, 0),
			});

			Utils.ArrayAreEqual(enemy.GetFootholdCells(), new[] {
				field.GetCell(4, 1),
				field.GetCell(3, 1),
				field.GetCell(3, 2),
			});

			Assert.IsFalse(manage.Move(strike, field.GetCell(1, 0)).IsValid());

			Assert.IsTrue(manage.Fight(strike, guards).IsValid());
			Assert.AreEqual(3, guards.GetDamage());
			Assert.AreEqual(0, strike.GetDamage());

			Assert.IsFalse(manage.Fight(strike, guards).IsValid());

			manage.EndTurn(player);

			Assert.AreEqual(1, engine.Turn.GetNumber());

			manage.EndTurn(enemy);
			
			Assert.AreEqual(2, engine.Turn.GetNumber());

			manage.EndTurn(player);

			Assert.AreEqual(3, engine.Turn.GetNumber());

			Assert.IsFalse(manage.Fight(strike, guards).IsValid());

			Assert.IsTrue(manage.Fight(guards, strike).IsValid());
			Assert.AreEqual(1, strike.GetDamage());
		}
	}
}
