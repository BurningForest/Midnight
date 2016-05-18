using System.Collections.Generic;

namespace Midnight.ChiefOperations.IoOptions
{
	public class CardOption
	{
		public int cardId;
		public AttackOptions attacks;
		public DeployOptions deploys;
		public MoveOptions   moves;
		public OrderOptions  orders;
		
		public bool IsEmpty ()
		{
			return null == attacks
				&& null == deploys
				&& null == moves
				&& null == orders;
		}
	}
}
