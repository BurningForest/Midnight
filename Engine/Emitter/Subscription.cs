using System.Reflection;

namespace Midnight.Engine.Emitter
{
	internal struct Subscription
	{
		public IListener listener;
		public MethodInfo method;
	}
}
