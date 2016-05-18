using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Abilities.Positioning;
using Midnight.Core;
using Midnight.Battlefield;
using System;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
	internal class DeploysCollector : Collector<Deployment, DeployOptions>
	{
		public DeploysCollector (Card card) : base(card) { }

		protected override DeployOptions GetOptions (Deployment ability)
		{
			if (ability.IsWithoutCell()) {
				return new DeployOptions() {};
			}

			var cells = new List<CellOption>();

			foreach (Cell cell in ability.GetAllowedCells()) {
				cells.Add(new CellOption() { x = cell.x, y = cell.y });
			}

			if (cells.Count == 0) {
				return null;
			} else {
				return new DeployOptions() { cells = cells.ToArray() };
			}
		}
	}
}
