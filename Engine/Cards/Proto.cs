using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midnight.Engine.Cards.Prototype
{
	public struct Proto
	{
		public string id;
		public int level;
		public Type type;
		public Subtype subtype;
		public Country country;

		public int power;
		public int defense;
		public int toughness;
		public int increase;
		public int cost;
	}
}
