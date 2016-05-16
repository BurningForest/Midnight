using Midnight.Cards;
using Midnight.Cards.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midnight.Battlefield
{
	public class Field
	{
		private int width;
		private int height;
		private List<Cell> cells = new List<Cell>();

		public Field SetSize (int width, int height)
		{
			this.width = width;
			this.height = height;

			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					cells.Add(new Cell(this, x, y));
				}
			}

			return this;
		}

		public List<Cell> GetCells ()
		{
			return cells;
		}

		private int GetIndex (int x, int y)
		{
			return x + y * width;
		}

		public bool IsSuitable (int x, int y)
		{
			return x >= 0 && x < this.width
				&& y >= 0 && y < this.height;
		}

		public Cell GetCell (int x, int y)
		{
			return IsSuitable(x, y)
				? cells[GetIndex(x, y)]
				: null;
		}

		public Cell GetCellSoft (int x, int y)
		{
			if (x < 0) x = width + x;
			if (y < 0) y = height + y;

			return GetCell(x, y);
		}

		public Cell GetCornerCell (bool opposite)
		{
			return GetCell(
				opposite ? width - 1 : 0,
				opposite ? height - 1 : 0
			);
		}

		public List<Cell> GetCellsByRow (int y)
		{
			if (y < 0 || y >= height) {
				throw new ArgumentOutOfRangeException("y is out of range");
			}

			var row = new List<Cell>();

			for (int x = 0; x < width; x++) {
				row.Add(GetCell(x, y));
			}

			return row;
		}

		public List<Cell> GetCellsByColumn (int x)
		{
			if (x < 0 || x >= width) {
				throw new ArgumentOutOfRangeException("x is out of range");
			}

			var column = new List<Cell>();

			for (int y = 0; y < height; y++) {
				column.Add(GetCell(x, y));
			}

			return column;
		}

		public List<FieldCard> GetAllCards ()
		{
			return GetCardsOf(cells);
		}

		public List<FieldCard> GetCardsOf (List<Cell> cells)
		{
			List<FieldCard> cards = new List<FieldCard>();

			foreach (Cell cell in cells) {
				FieldCard card = cell.GetCard();

				if (card != null) {
					cards.Add(card);
				}
			}

			return cards;
		}

	}
}
