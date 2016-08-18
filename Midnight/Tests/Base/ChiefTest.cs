using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.ChiefOperations;
using System;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class ChiefTest
	{
		[TestMethod]
		public void ChiefIndex ()
		{
			var chief = new Chief(1);

			Assert.AreEqual(1, chief.Index);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void DoubleStartGame ()
		{
			var engine = new Engine();
			engine.turn.StartWith(engine.chiefs[0]);
			engine.turn.StartWith(engine.chiefs[1]);
		}
	}
}
