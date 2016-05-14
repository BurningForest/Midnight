using System;
using Midnight.Engine.Cards;
using System.Collections.Generic;

namespace Midnight.Engine.Battlefield
{
	public class Cell
	{
		private readonly Field field;

		public readonly int x;
		public readonly int y;

		private FieldCard card;

		public Cell (Field field, int x, int y)
		{
			this.field = field;
			this.x = x;
			this.y = y;
		}

		public bool IsBusy ()
		{
			return card != null;
		}

		public Card GetCard ()
		{
			return card;
		}

		public void SetCard (FieldCard card)
		{
			if (IsBusy()) {
				throw new Exception("Cell is not empty");
			}

			this.card = card;
		}

		public void RemoveCard (FieldCard card)
		{
			if (this.card != card) {
				throw new ArgumentException("Try to remove wrong card");
			}

			this.card = null;
		}

		// check for neighbors
		public Offset DistanceTo(Cell cell)
		{
			return new Offset() {
				x = Math.Abs(cell.x - x),
				y = Math.Abs(cell.y - y)
			};
		}

		public bool IsCornerTo (Cell cell)
		{
			return cell != this
				&& DistanceTo(cell).IsEquals(1, 1);
		}
		
		public bool IsCloseTo (Cell cell)
		{
			var distance = DistanceTo(cell);

			return cell != this && (
				distance.IsEquals(1, 0) || distance.IsEquals(0, 1)
			);
		}
		
		public bool IsRunTo (Cell cell)
		{
			var distance = DistanceTo(cell);

			return cell != this && (
				distance.IsEquals(2, 0) || distance.IsEquals(0, 2)
			);
		}

		public bool IsAdjoiningTo (Cell cell)
		{
			var distance = DistanceTo(cell);

			return cell != this
				&& distance.x <= 1
				&& distance.y <= 1;
		}

		// getting neighbors

		public struct Offset
		{
			public int x;
			public int y;

			public bool IsEquals(int x, int y)
			{
				return this.x == x && this.y == y;
			}
		}

		private static Offset[] CLOSEST_OFFSETS = {
			new Offset() { x =  1, y =  0 },
			new Offset() { x = -1, y =  0 },
			new Offset() { x =  0, y =  1 },
			new Offset() { x =  0, y = -1 },
		};

		private static Offset[] CORNER_OFFSETS = {
			new Offset() { x =  1, y =  1 },
			new Offset() { x = -1, y =  1 },
			new Offset() { x =  1, y = -1 },
			new Offset() { x = -1, y = -1 },
		};

		private static Offset[] RUN_OFFSETS = {
			new Offset() { x =  2, y =  0 },
			new Offset() { x = -2, y =  0 },
			new Offset() { x =  0, y =  2 },
			new Offset() { x =  0, y = -2 },
		};

		private List<Cell> AppendCellsTo (List<Cell> source, Offset[] offsets)
		{
			foreach (var point in offsets) {
				Cell cell = field.GetCell(x + point.x, y + point.y);

				if (cell != null) {
					source.Add(cell);
				}
			}

			return source;
		}

		public List<Cell> GetClosestCells () // 2 horisontal + 2 vertical closest cells
		{
			return AppendCellsTo(new List<Cell>(), CLOSEST_OFFSETS);
		}

		public List<Cell> GetCornerCells () // 4 diagonal cells
		{
			return AppendCellsTo(new List<Cell>(), CORNER_OFFSETS);
		}

		public List<Cell> GetAdjoiningCells () // 8 adjoining cells
		{
			return AppendCellsTo(GetClosestCells(), CORNER_OFFSETS);
		}

		public List<Cell> GetRunCells () // 8 adjoining cells
		{
			return AppendCellsTo(GetAdjoiningCells(), RUN_OFFSETS);
		}
	}
}
