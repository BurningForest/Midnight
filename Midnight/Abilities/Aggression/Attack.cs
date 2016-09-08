using Midnight.Core;

namespace Midnight.Abilities.Aggression
{
	public class Attack : Aggression
	{
		public override Status Validate ()
		{
			var status = base.Validate();

			if (status != Status.Success)
            {
				return status;
			}

			return !Card.GetChief().IsTurnOwner() ? Status.NotTurnOfSource : Status.Success;
		}
	}
}
