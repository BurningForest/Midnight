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
			public Hq hq;
			public Card light;
			public Card heavy;
			public Card spatg;
		}

		private Bank CreateBank ()
		{
			var bank = new Bank();
			bank.engine = new Engine();
			bank.player = bank.engine.chiefs[0];
			bank.enemy  = bank.engine.chiefs[1];
			bank.hq     = bank.player.cards.factory.CreateDefaultHq<HqGuards>();
			bank.light  = bank.player.cards.factory.Create<TankLight>();
			bank.heavy  = bank.enemy .cards.factory.Create<TankHeavy>();
			bank.spatg  = bank.enemy .cards.factory.Create<TankSpatg>();
			bank.engine.turn.StartWith(bank.player);
			return bank;
		}

		private Bank CloneBank (Bank source)
		{
			var bank = new Bank();
			bank.engine = source.engine.Clone();
			bank.player = bank.engine.chiefs[0];
			bank.enemy  = bank.engine.chiefs[1];
			bank.hq     = bank.player.cards.GetHq();
			bank.light  = bank.player.cards.GetAll().Find(c => c is TankLight);
			bank.heavy  = bank.enemy .cards.GetAll().Find(c => c is TankHeavy);
			bank.spatg  = bank.enemy .cards.GetAll().Find(c => c is TankSpatg);
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
			
			Assert.AreNotSame(source.hq, cloned.hq);
			Assert.AreNotSame(source.light, cloned.light);
			Assert.AreNotSame(source.heavy, cloned.heavy);
			Assert.AreNotSame(source.spatg, cloned.spatg);

			Assert.AreEqual(source.hq.id, cloned.hq.id);
			Assert.AreEqual(source.spatg.id, cloned.spatg.id);

			Assert.AreSame(source.hq, source.engine.cache.Get(source.hq.id));
			Assert.AreSame(cloned.hq, cloned.engine.cache.Get(cloned.hq.id));

			Assert.AreNotSame(source.hq.GetLocation(), cloned.hq.GetLocation());
			Assert.AreNotSame(source.hq.abilities, cloned.hq.abilities);
			Assert.AreNotSame(source.hq.modifiers, cloned.hq.modifiers);
		}

		[TestMethod]
		public void NoCloneInfluenceOnSource ()
		{
			var source = CreateBank();
			var cloned = CloneBank(source);

			var manage = new Manage(cloned.engine);
				
			manage.Damage(2, cloned.hq, cloned.hq);

			cloned.hq.abilities.Add(new FirstStrike());

			Assert.AreEqual(2, cloned.hq.GetDamage());
			Assert.AreEqual(0, source.hq.GetDamage());
			Assert.IsTrue (cloned.hq.abilities.Has<FirstStrike>());
			Assert.IsFalse(source.hq.abilities.Has<FirstStrike>());

			manage.Kill(cloned.hq);

			Assert.IsTrue(cloned.hq.IsDead());
			Assert.IsFalse(source.hq.IsDead());
		}

		[TestMethod]
		public void NoSourceInfluenceOnClone ()
		{
			var source = CreateBank();
			var cloned = CloneBank(source);

			var manage = new Manage(source.engine);

			manage.Damage(2, source.hq, source.hq);

			source.hq.abilities.Add(new FirstStrike());

			Assert.AreEqual(2, source.hq.GetDamage());
			Assert.AreEqual(0, cloned.hq.GetDamage());
			Assert.IsTrue(source.hq.abilities.Has<FirstStrike>());
			Assert.IsFalse(cloned.hq.abilities.Has<FirstStrike>());

			manage.Kill(source.hq);

			Assert.IsTrue(source.hq.IsDead());
			Assert.IsFalse(cloned.hq.IsDead());
		}
	}
}
