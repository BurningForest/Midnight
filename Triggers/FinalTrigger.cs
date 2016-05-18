using Midnight.Actions;
using Midnight.ChiefOperations;

namespace Midnight.Triggers
{
	public class FinalTrigger : Trigger
	{
		protected void Win (Chief chief)
		{
			engine.actions.Delay(new Final(chief));
		}
	}
}
