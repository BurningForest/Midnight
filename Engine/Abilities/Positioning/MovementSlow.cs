using System;
using Midnight.Battlefield;

namespace Midnight.Abilities.Positioning
{
	public class MovementSlow : Movement
	{
		public override int GetMaxQuantity ()
		{
			return 2;
		}
	}
}
