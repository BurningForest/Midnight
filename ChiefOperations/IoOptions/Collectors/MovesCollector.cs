using System;
using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Abilities.Positioning;
using Midnight.Core;
using Midnight.Battlefield;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
	internal class MovesCollector : Collector<Movement, MoveOptions>
	{
		public MovesCollector (Card card) : base(card) { }

		protected override MoveOptions GetOptions (Movement ability)
		{
			var cells = new List<CellOption>();

			foreach (Cell cell in ability.GetAllowedCells()) {
				cells.Add(new CellOption() { x = cell.x, y = cell.y });
			}

			if (cells.Count == 0) {
				return null;
			} else {
				return new MoveOptions() { cells = cells.ToArray() };
			}
		}
	}
}
