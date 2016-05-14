using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midnight.Engine.ActionManager;
using Midnight.Engine.ActionManager.Events;
using Midnight.Engine.Emitter;

namespace Midnight.Tests.Base
{
	[TestClass]
	public class ActionManager
	{
		private class FooAction : GameAction<FooAction>
		{
			public static int value = 42;

			public int GetValue ()
			{
				return value;
			}
		}
		private class BarAction : GameAction<BarAction>
		{
			public static int value = 113;

			public int GetValue ()
			{
				return value;
			}
		}

		private class MyListener : IListener<Before<FooAction>>, IListener<Before<BarAction>>
		{
			public int qux = 0;

			public void On (Before<FooAction> e)
			{
				qux = e.action.GetValue();
			}

			public void On (Before<BarAction> e)
			{
				qux = e.action.GetValue();
			}
		}

		[TestMethod]
		public void EventPublising ()
		{
			var emitter = new EventEmitter();

			var listener = new MyListener();
			emitter.Subscribe(listener);

			Assert.AreEqual(0, listener.qux);

			emitter.Publish(new Before<FooAction>(new FooAction()));
			Assert.AreEqual(FooAction.value, listener.qux);

			emitter.Publish(new Before<BarAction>(new BarAction()));
			Assert.AreEqual(BarAction.value, listener.qux);
		}
	}
}
