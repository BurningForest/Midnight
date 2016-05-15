using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.ChiefOperations;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class ChiefTest
	{
		[TestMethod]
		public void ChiefIndex ()
		{
			var chief = new Chief(1);

			Assert.AreEqual(1, chief.index);
		}
	}
}
