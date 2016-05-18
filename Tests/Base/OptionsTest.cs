using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Utils;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class OptionsTest
	{
		[TestMethod]
		public void DeploymentOptions ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);

			var player = engine.chiefs[0];
			var enemy  = engine.chiefs[1];


		}
	}
}
