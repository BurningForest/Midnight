using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midnight.ChiefOperations.IoOptions
{
	public class CardOption
	{
		public int cardId;
		public List<ISingleOption> attacks;
		public List<ISingleOption> deploys;
		public List<ISingleOption> moves;
		public List<ISingleOption> orders;
	}
}
