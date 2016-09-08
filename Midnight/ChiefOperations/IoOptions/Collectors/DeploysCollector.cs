using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Abilities.Positioning;
using Midnight.Battlefield;

namespace Midnight.ChiefOperations.IoOptions.Collectors
{
	internal class DeploysCollector : Collector<Deployment, DeployOptions>
	{
		public DeploysCollector (Card card) : base(card) { }

		protected override DeployOptions GetOptions (Deployment ability)
		{
			if (ability.IsWithoutCell()) 
{
				return new DeployOptions();
			}

			var cells = new List<CellOption>();

			foreach (Cell cell in ability.GetAllowedCells())
            {
				cells.Add(new CellOption { X = cell.X, Y = cell.Y });
			}

		    return cells.Count == 0
		        ? null
		        : new DeployOptions
		        {
		            Type = TargetType.Cell,
		            Cells = cells.ToArray()
		        };
		}
	}
}
