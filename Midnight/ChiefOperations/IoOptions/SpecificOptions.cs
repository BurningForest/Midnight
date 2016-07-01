namespace Midnight.ChiefOperations.IoOptions
{
	public class CellOption
	{
		public int x;
		public int y;
	}
	public class TargetOption
	{
		public int targetId;
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
		public CellOption[] cells;
	}
	public class DeployOptions : SpecificOptions
	{
		public TargetType type = TargetType.Global;
		public CellOption[] cells;
	}
	public class AttackOptions : SpecificOptions
	{
		public TargetOption[] targets;
	}
	public class OrderOptions : SpecificOptions
	{
		public TargetType type = TargetType.Global;
		public TargetOption[] targets;
	}
}
