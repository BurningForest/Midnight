using System;
using System.Collections.Generic;
using System.Linq;
using Midnight.Cards.Types;

namespace Midnight.Battlefield
{
	public class Cell
	{
		private readonly Field _field;

        private FieldCard _card;

        public int X { get; }
		public int Y { get; }

		public Cell (Field field, int x, int y)
		{
			_field = field;
			X = x;
			Y = y;
		}

		public bool IsBusy ()
		{
			return _card != null;
		}

		public FieldCard GetCard ()
		{
			return _card;
		}

		public void SetCard (FieldCard card)
		{
			if (IsBusy())
            {
				throw new ArgumentException("Cell is not empty");
			}

			_card = card;
		}

		public void RemoveCard (FieldCard card)
		{
			if (this._card != card) {
				throw new ArgumentException("Try to remove wrong card");
			}

			this._card = null;
		}

		// check for neighbors
		public Offset DistanceTo (Cell cell)
		{
			return new Offset
			{
				X = Math.Abs(cell.X - X),
				Y = Math.Abs(cell.Y - Y)
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
				&& distance.X <= 1
				&& distance.Y <= 1;
		}

		// getting neighbors

		public struct Offset
		{
			public int X;
			public int Y;

			public bool IsEquals (int x, int y)
			{
				return X == x && Y == y;
			}
		}

		private static readonly Offset[] ClosestOffsets = {
			new Offset { X =  1, Y =  0 },
			new Offset { X = -1, Y =  0 },
			new Offset { X =  0, Y =  1 },
			new Offset { X =  0, Y = -1 },
		};

		private static readonly Offset[] CornerOffsets = {
			new Offset { X =  1, Y =  1 },
			new Offset { X = -1, Y =  1 },
			new Offset { X =  1, Y = -1 },
			new Offset { X = -1, Y = -1 },
		};

		private static readonly Offset[] RunOffsets = {
			new Offset { X =  2, Y =  0 },
			new Offset { X = -2, Y =  0 },
			new Offset { X =  0, Y =  2 },
			new Offset { X =  0, Y = -2 },
		};

		private List<Cell> AppendCellsTo (List<Cell> source, Offset[] offsets)
		{
		    source.AddRange(offsets.Select(point => _field.GetCell(X + point.X, Y + point.Y)).Where(cell => cell != null));

		    return source;
		}

	    public List<Cell> GetClosestCells () // 2 horisontal + 2 vertical closest cells
		{
			return AppendCellsTo(new List<Cell>(), ClosestOffsets);
		}

		public List<Cell> GetCornerCells () // 4 diagonal cells
		{
			return AppendCellsTo(new List<Cell>(), CornerOffsets);
		}

		public List<Cell> GetAdjoiningCells () // 8 adjoining cells
		{
			return AppendCellsTo(GetClosestCells(), CornerOffsets);
		}

		public List<Cell> GetRunCells () // 8 adjoining cells + 4 run cells
		{
			return AppendCellsTo(GetAdjoiningCells(), RunOffsets);
		}
	}
}
