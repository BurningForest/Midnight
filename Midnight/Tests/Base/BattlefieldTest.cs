using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Tests.TestInstances;
using System;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class BattlefieldTest
	{
		public static Battlefield.Field CreateField ()
		{
			var field = new Battlefield.Field();
			field.SetSize(5, 3);
			return field;
		}

		[TestMethod]
		public void FieldCreation ()
		{
			var field = CreateField();
			Assert.AreEqual(15, field.GetCells().Count);
			Assert.AreEqual(3, field.GetCell(3, 2).X);
			Assert.AreEqual(2, field.GetCell(3, 2).Y);
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
		public void GettingRun ()
		{
			var field = CreateField();
			var adjoining = field.GetCell(3, 1).GetRunCells();

			Assert.AreEqual(9, adjoining.Count);
			Assert.IsTrue(adjoining.Contains(field.GetCell(1, 1)));
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
			Assert.AreEqual(1, corner[0].X);
			Assert.AreEqual(1, corner[0].Y);
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

		[TestMethod]
		public void GettingSoftCell ()
		{
			var field = CreateField();

			Assert.AreEqual(field.GetCellSoft(-1, -1), field.GetCell(4, 2));
			Assert.AreEqual(field.GetCellSoft(-2, 1), field.GetCell(3, 1));
		}

		[TestMethod]
		public void GettingeEmptyCards ()
		{
			var field = CreateField();

			Assert.AreEqual(0, field.GetAllCards().Count);
		}

		[TestMethod]
		public void GettingAllCards ()
		{
			var field = CreateField();
			var Light = new TankLight();
			var Spatg = new TankSpatg();
			var Heavy = new TankHeavy();

			Light.GetFieldLocation().ToCell(field.GetCell(1, 1));
			Spatg.GetFieldLocation().ToCell(field.GetCell(2, 1));

			var allCards = field.GetAllCards();

			Assert.AreEqual(2, allCards.Count);
			Assert.IsTrue(allCards.Contains(Light));
			Assert.IsTrue(allCards.Contains(Spatg));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void MoveToBusyCell ()
		{
			var field = CreateField();
			var cell = field.GetCell(1, 1);
			var Light = new TankLight();
			var Spatg = new TankSpatg();

			Light.GetFieldLocation().ToCell(cell);
			Spatg.GetFieldLocation().ToCell(cell);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveFromWrongCell ()
		{
			var field = CreateField();
			var cell = field.GetCell(1, 1);
			var Light = new TankLight();
			var Spatg = new TankSpatg();

			Light.GetFieldLocation().ToCell(cell);
			cell.RemoveCard(Spatg);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GettingWrongRow ()
		{
			CreateField().GetCellsByRow(7);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GettingWrongColumn ()
		{
			CreateField().GetCellsByColumn(7);
		}
	}
}
