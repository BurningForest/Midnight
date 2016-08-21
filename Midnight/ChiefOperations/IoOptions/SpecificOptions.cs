using System.Collections.Generic;
using static Midnight.ChiefOperations.Emulated;

namespace Midnight.ChiefOperations.IoOptions
{
	public class CellOption
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
	public class TargetOption
	{
		public int TargetId { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
	public enum TargetType
	{
		Global,
		Card,
		Cell
	}

	public class SpecificOptions { }

	public class MoveOptions : SpecificOptions
	{
		public CellOption[] Cells { get; set; }
	}
	public class DeployOptions : SpecificOptions
	{
		public TargetType Type = TargetType.Global;
		public CellOption[] Cells { get; set; }
	}
	public class AttackOptions : SpecificOptions
	{
		public TargetOption[] Targets { get; set; } 
	}
	public class OrderOptions : SpecificOptions
	{
		public TargetType Type = TargetType.Global;
		public TargetOption[] Targets { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}
