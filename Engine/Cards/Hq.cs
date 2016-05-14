using System;
using System.Collections.Generic;
using Midnight.Engine.Battlefield;

namespace Midnight.Engine.Cards
{
	public abstract class Hq : FieldCard
	{
		public override bool IsHq()
		{
			return true;
		}

		internal List<Cell> GetFootholdCells ()
		{
			throw new NotImplementedException();
		}
	}
}
