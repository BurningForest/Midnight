using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
	public class Attack : Aggression
	{
		public override Status Validate ()
		{
			var status = base.Validate();

			if (status != Status.Success) {
				return status;
			}

			if (!card.GetChief().IsTurnOwner()) {
				return Status.NotTurnOfSource;
			}

			return Status.Success;
		}
	}
}
