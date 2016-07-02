using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Abilities.Passive;
using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using System.Linq;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class EmulationTest
	{
		private struct Bank
		{
			public Engine engine;
			public Chief player;
			public Chief enemy;
			public Hq HQ;
			public Card Light;
			public Card Heavy;
			public Card Spatg;
		}

		private Bank CreateBank ()
		{
			var bank = new Bank();
			bank.engine = new Engine();
			bank.player = bank.engine.chiefs[0];
			bank.enemy  = bank.engine.chiefs[1];
			bank.HQ     = bank.player.cards.factory.CreateDefaultHq<HqGuards>();
			bank.Light  = bank.player.cards.factory.Create<TankLight>();
			bank.Heavy  = bank.enemy .cards.factory.Create<TankHeavy>();
			bank.Spatg  = bank.enemy .cards.factory.Create<TankSpatg>();
			bank.engine.turn.StartWith(bank.player);
			return bank;
		}

		private Bank CloneBank (Bank source)
		{
			var bank = new Bank();
			bank.engine = source.engine.Clone();
			bank.player = bank.engine.chiefs[0];
			bank.enemy  = bank.engine.chiefs[1];
			bank.HQ     = bank.player.cards.GetHq();
			bank.Light  = bank.player.cards.GetAll().Find(c => c is TankLight);
			bank.Heavy  = bank.enemy .cards.GetAll().Find(c => c is TankHeavy);
			bank.Spatg  = bank.enemy .cards.GetAll().Find(c => c is TankSpatg);
			return bank;
		}

		[TestMethod]
		public void BaseEmulation ()
		{
			var source = CreateBank();
			var cloned = CloneBank(source);

			Assert.AreNotSame(source.engine, cloned.engine);
			Assert.AreNotSame(source.player, cloned.player);
			Assert.AreNotSame(source.enemy, cloned.enemy);
			Assert.AreNotSame(source.engine.turn.GetOwner(), cloned.engine.turn.GetOwner());
			Assert.AreEqual(source.engine.turn.GetOwner().index, cloned.engine.turn.GetOwner().index);
		}

		[TestMethod]
		public void CorrectCards ()
		{
			var source = CreateBank();
			var cloned = CloneBank(source);
			
			Assert.AreNotSame(source.HQ, cloned.HQ);
			Assert.AreNotSame(source.Light, cloned.Light);
			Assert.AreNotSame(source.Heavy, cloned.Heavy);
			Assert.AreNotSame(source.Spatg, cloned.Spatg);

			Assert.AreEqual(source.HQ.id, cloned.HQ.id);
			Assert.AreEqual(source.Spatg.id, cloned.Spatg.id);

			Assert.AreSame(source.HQ, source.engine.cache.Get(source.HQ.id));
			Assert.AreSame(cloned.HQ, cloned.engine.cache.Get(cloned.HQ.id));

			Assert.AreNotSame(source.HQ.GetLocation(), cloned.HQ.GetLocation());
			Assert.AreNotSame(source.HQ.abilities, cloned.HQ.abilities);
			Assert.AreNotSame(source.HQ.modifiers, cloned.HQ.modifiers);
		}

		[TestMethod]
		public void NoCloneInfluenceOnSource ()
		{
			var source = CreateBank();
			var cloned = CloneBank(source);

			var manage = new Manage(cloned.engine);
				
			manage.Damage(2, cloned.HQ, cloned.HQ);

			cloned.HQ.abilities.Add(new FirstStrike());

			Assert.AreEqual(2, cloned.HQ.GetDamage());
			Assert.AreEqual(0, source.HQ.GetDamage());
			Assert.IsTrue (cloned.HQ.abilities.Has<FirstStrike>());
			Assert.IsFalse(source.HQ.abilities.Has<FirstStrike>());

			manage.Kill(cloned.HQ);

			Assert.IsTrue(cloned.HQ.IsDead());
			Assert.IsFalse(source.HQ.IsDead());
		}

		[TestMethod]
		public void NoSourceInfluenceOnClone ()
		{
			var source = CreateBank();
			var cloned = CloneBank(source);

			var manage = new Manage(source.engine);

			manage.Damage(2, source.HQ, source.HQ);

			source.HQ.abilities.Add(new FirstStrike());

			Assert.AreEqual(2, source.HQ.GetDamage());
			Assert.AreEqual(0, cloned.HQ.GetDamage());
			Assert.IsTrue(source.HQ.abilities.Has<FirstStrike>());
			Assert.IsFalse(cloned.HQ.abilities.Has<FirstStrike>());

			manage.Kill(source.HQ);

			Assert.IsTrue(source.HQ.IsDead());
			Assert.IsFalse(cloned.HQ.IsDead());
		}
	}
}
