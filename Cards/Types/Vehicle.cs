using System;
using System.Linq;

namespace Midnight.Cards.Types
{
	public abstract class Vehicle : FieldCard
	{
		public override bool IsSpotted ()
		{
			return GetAdjoiningCards().Any(card => card.IsEnemyOf(this));
		}
	}
}
