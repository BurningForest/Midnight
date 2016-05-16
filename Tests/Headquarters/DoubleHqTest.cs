using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Core;
using Midnight.Tests.TestInstances;
using Midnight.Triggers;
using Midnight.Utils;

namespace Midnight.Tests.Headquarters
{
	[TestClass]
	public class DoubleHqTest
	{
		[TestMethod]
		public void DoubleHq ()
		{
			var engine = new Engine();
			var logger = new Logger(engine);
			var manage = new Manage(engine);

			var field  = engine.field;
			var player = engine.chiefs[0];

			var strike = player.cards.factory.Create<HqStrike>();
			var guards = player.cards.factory.Create<HqGuards>();

			manage.Position(strike, field.GetCell(0, 0));
			manage.Position(guards, field.GetCell(0, 2));

			Utils.ArrayAreEqual(player.GetFootholdCells(), new[] {
				field.GetCell(0, 1),
				field.GetCell(1, 2),
				field.GetCell(1, 1),
				field.GetCell(1, 0),
			});

			manage.Kill(strike);

			Utils.ArrayAreEqual(player.GetFootholdCells(), new[] {
				field.GetCell(0, 1),
				field.GetCell(1, 2),
				field.GetCell(1, 1)
			});
		}
	}
}
