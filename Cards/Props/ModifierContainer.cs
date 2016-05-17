using System;
using System.Collections.Generic;
using System.Linq;

namespace Midnight.Cards.Props
{
	public class ModifierContainer
	{
		private List<Modifier> modifiers = new List<Modifier>();

		public void Add(Modifier modifier)
		{
			modifiers.Add(modifier);
		}

		public List<Modifier> GetAll ()
		{
			return modifiers;
		}

		public List<Modifier> GetPropertyModifiers<TProperty> (TProperty property)
			where TProperty : Property
		{
			return modifiers
				.Where(m => m.GetProperty() == property)
				.ToList();
		}

		public int GetPropertySum<TProperty> (TProperty property)
			where TProperty : Property
		{
			return GetPropertyModifiers(property)
				.Sum(m => m.GetValue());
		}

		internal void CloneFrom (ModifierContainer modifiers, Engine.ClonedEngine engine)
		{
			foreach (var modifier in modifiers.GetAll()) {
				Add(modifier.CloneFor(engine));
			}
		}
	}
}
