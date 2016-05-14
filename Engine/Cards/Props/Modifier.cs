using System;

namespace Midnight.Engine.Cards.Props
{
	public class Modifier
	{
		private Property property;
		private Card target = null;
		private Card source = null;
		private int value = 0;

		public Modifier (Property property)
		{
			this.property = property;
		}

		public Property GetProperty ()
		{
			return property;
		}

		public Card GetTarget ()
		{
			return target;
		}

		public Modifier SetTarget (Card target)
		{
			if (this.target != null) {
				throw new ArgumentException("Target cant be changed");
			}

			this.target = target;
			return this;
		}

		public Card GetSource ()
		{
			return source;
		}

		public Modifier SetSource (Card source)
		{
			if (this.source != null) {
				throw new ArgumentException("Source cant be changed");
			}

			this.source = source;
			return this;
		}

		public int GetValue ()
		{
			return value;
		}

		public Modifier GetValue (int value)
		{
			this.value = value;
			return this;
		}
	}
}
