using System;

namespace Midnight.Cards.Props
{
	public class Modifier
	{
		private readonly Property _property;
		private Card _target;
		private Card _source;
		private int _value;

		public Modifier (Property property)
		{
			_property = property;
		}

		public Property GetProperty ()
		{
			return _property;
		}

		public Card GetTarget ()
		{
			return _target;
		}

		public Modifier SetTarget (Card target)
		{
			if (this._target != null)
            {
				throw new ArgumentException("Target cant be changed");
			}

			_target = target;
			return this;
		}

		public Card GetSource ()
		{
			return _source;
		}

		public Modifier SetSource (Card source)
		{
			if (_source != null)
            {
				throw new ArgumentException("Source cant be changed");
			}

			_source = source;
			return this;
		}

		public int GetValue ()
		{
			return _value;
		}

		internal Modifier CloneFor (Engine.ClonedEngine engine)
		{
			return new Modifier(_property)
				.SetValue(_value)
				.SetTarget(engine.cache.Get(_target.Id))
				.SetSource(engine.cache.Get(_source.Id));
		}

		public Modifier SetValue (int value)
		{
			_value = value;
			return this;
		}
	}
}
