using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Midnight.Tests
{
	public class Utils
	{
		public static void ArrayAreEqual<T> (ICollection<T> value, ICollection<T> expect)
		{
			Assert.AreEqual(expect.Count, value.Count);

			foreach (var item in expect) {
				Assert.IsTrue(value.Contains(item));
			}
		}
	}
}
