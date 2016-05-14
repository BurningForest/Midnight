using System;
using Midnight.Engine.Battlefield;

namespace Midnight.Engine.Abilities.Positioning
{
	public class MovementSlow : Movement
	{
		public override int GetMaxQuantity ()
		{
			return 2;
		}
	}
}
