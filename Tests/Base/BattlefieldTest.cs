using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class BattlefieldTest
	{
		public static Engine.Battlefield.Field CreateField ()
		{
			var field = new Engine.Battlefield.Field();
			field.SetSize(5, 3);
			return field;
		}

		[TestMethod]
		public void FieldCreation ()
		{
			var field = CreateField();
			Assert.AreEqual(15, field.GetCells().Count);
			Assert.AreEqual(3, field.GetCell(3, 2).x);
			Assert.AreEqual(2, field.GetCell(3, 2).y);
		}

		[TestMethod]
		public void GettingClosest ()
		{
			var field = CreateField();
			var closest = field.GetCell(3, 1).GetClosestCells();

			Assert.AreEqual(4, closest.Count);
			Assert.IsTrue(closest.Contains(field.GetCell(2, 1)));
			Assert.IsTrue(closest.Contains(field.GetCell(4, 1)));
			Assert.IsTrue(closest.Contains(field.GetCell(3, 0)));
			Assert.IsTrue(closest.Contains(field.GetCell(3, 2)));
		}

		[TestMethod]
		public void GettingAdjoining ()
		{
			var field = CreateField();
			var adjoining = field.GetCell(3, 1).GetAdjoiningCells();

			Assert.AreEqual(8, adjoining.Count);
		}

		[TestMethod]
		public void GettingAdjoiningSided ()
		{
			var field = CreateField();
			var adjoining = field.GetCell(3, 0).GetAdjoiningCells();

			Assert.AreEqual(5, adjoining.Count);
		}

		[TestMethod]
		public void GettingZeroCorner ()
		{
			var field = CreateField();
			var corner = field.GetCell(0, 0).GetCornerCells();

			Assert.AreEqual(1, corner.Count);
			Assert.AreEqual(1, corner[0].x);
			Assert.AreEqual(1, corner[0].y);
		}

		[TestMethod]
		public void GettingCorner ()
		{
			var field = CreateField();
			var corner = field.GetCell(3, 1).GetCornerCells();

			Assert.AreEqual(4, corner.Count);
			Assert.IsTrue(corner.Contains(field.GetCell(2, 0)));
			Assert.IsTrue(corner.Contains(field.GetCell(4, 0)));
			Assert.IsTrue(corner.Contains(field.GetCell(2, 2)));
			Assert.IsTrue(corner.Contains(field.GetCell(4, 2)));
		}

		[TestMethod]
		public void GettingRow ()
		{
			var field = CreateField();
			var row = field.GetCellsByRow(1);

			Assert.AreEqual(5, row.Count);
			Assert.IsTrue(row.Contains(field.GetCell(0, 1)));
			Assert.IsTrue(row.Contains(field.GetCell(1, 1)));
			Assert.IsTrue(row.Contains(field.GetCell(2, 1)));
			Assert.IsTrue(row.Contains(field.GetCell(3, 1)));
			Assert.IsTrue(row.Contains(field.GetCell(4, 1)));
		}

		[TestMethod]
		public void GettingColumn ()
		{
			var field = CreateField();
			var row = field.GetCellsByColumn(4);

			Assert.AreEqual(3, row.Count);
			Assert.IsTrue(row.Contains(field.GetCell(4, 0)));
			Assert.IsTrue(row.Contains(field.GetCell(4, 1)));
			Assert.IsTrue(row.Contains(field.GetCell(4, 2)));
		}
	}
}
