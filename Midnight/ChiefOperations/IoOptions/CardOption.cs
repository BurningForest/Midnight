namespace Midnight.ChiefOperations.IoOptions
{
	public class CardOption
	{
		public int CardId;
		public AttackOptions Attacks { get; set; }
		public DeployOptions Deploys { get; set; }
        public MoveOptions Moves { get; set; }
        public OrderOptions Orders { get; set; }

        public bool IsEmpty ()
		{
			return null == Attacks
				&& null == Deploys
				&& null == Moves
				&& null == Orders;
		}
	}
}
