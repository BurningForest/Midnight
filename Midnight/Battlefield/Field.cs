using Midnight.Cards.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Midnight.Battlefield
{
	public class Field
	{
		private int _width;
		private int _height;
		private readonly List<Cell> _cells = new List<Cell>();

		/**
		 *              [HQ1]
		 *   02 12 22 32 42 
		 *   01 11 21 31 41
		 *   00 10 20 30 40
		 * [HQ0] 
		 */
		public Field SetSize (int width, int height)
		{
			_width = width;
			_height = height;

			for (int y = 0; y < height; y++)
            {
				for (int x = 0; x < width; x++)
                {
					_cells.Add(new Cell(this, x, y));
				}
			}

			return this;
		}

		public List<Cell> GetCells ()
		{
			return _cells;
		}

		private int GetIndex (int x, int y)
		{
			return x + y * _width;
		}

		public bool IsSuitable (int x, int y)
		{
			return x >= 0 && x < _width
				&& y >= 0 && y < _height;
		}

		public Cell GetCell (int x, int y)
		{
			return IsSuitable(x, y)
				? _cells[GetIndex(x, y)]
				: null;
		}

		public Cell GetCellSoft (int x, int y)
		{
			if (x < 0) x = _width + x;
			if (y < 0) y = _height + y;

			return GetCell(x, y);
		}

		public Cell GetCornerCell (bool opposite)
		{
			return GetCell(
				opposite ? _width - 1 : 0,
				opposite ? _height - 1 : 0
			);
		}

		public List<Cell> GetCellsByRow (int y)
		{
			if (y < 0 || y >= _height)
            {
				throw new ArgumentOutOfRangeException("Y is out of range");
			}

			var row = new List<Cell>();

			for (int x = 0; x < _width; x++) {
				row.Add(GetCell(x, y));
			}

			return row;
		}

		public List<Cell> GetCellsByColumn (int x)
		{
			if (x < 0 || x >= _width) {
				throw new ArgumentOutOfRangeException("X is out of range");
			}

			var column = new List<Cell>();

			for (int y = 0; y < _height; y++)
            {
				column.Add(GetCell(x, y));
			}

			return column;
		}

		public List<FieldCard> GetAllCards ()
		{
			return GetCardsOf(_cells);
		}

		public List<FieldCard> GetCardsOf (List<Cell> cells)
		{
		    return cells.Select(cell => cell.GetCard()).Where(card => card != null).ToList();
		}
	}
}
