using System;
using Midnight.Engine.Cards;
using Midnight.Engine.Core;
using Midnight.Engine.Battlefield;

namespace Midnight.Engine.Abilities.Positioning
{
	public abstract class Deployment : CardActiveAbility<ForefrontCard>
	{
		public override Status Validate ()
		{
			throw new NotImplementedException();
		}

		public Status Validate (Cell cell)
		{
			throw new NotImplementedException();
		}

		public void Activate ()
		{
			throw new NotImplementedException();
		}
	}
}
