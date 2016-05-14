using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midnight.Engine.Cards
{
	public class Subtype
	{
		public class HqSubtype : Subtype { }
		public class VehicleSubtype : Subtype { }
		public class PlatoonSubtype : Subtype { }
		public class OrderSubtype : Subtype { }
		
		public static readonly HqSubtype beginner = new HqSubtype();
		public static readonly HqSubtype strike = new HqSubtype();
		public static readonly HqSubtype guards = new HqSubtype();
		public static readonly HqSubtype consolidated = new HqSubtype();
		
		public static readonly VehicleSubtype light = new VehicleSubtype();
		public static readonly VehicleSubtype medium = new VehicleSubtype();
		public static readonly VehicleSubtype heavy = new VehicleSubtype();
		public static readonly VehicleSubtype spatg = new VehicleSubtype();
		public static readonly VehicleSubtype spg = new VehicleSubtype();
		
		public static readonly PlatoonSubtype scout = new PlatoonSubtype();
		public static readonly PlatoonSubtype communications = new PlatoonSubtype();
		public static readonly PlatoonSubtype artillery = new PlatoonSubtype();
		public static readonly PlatoonSubtype medic = new PlatoonSubtype();
		public static readonly PlatoonSubtype intendancy = new PlatoonSubtype();
		
		public static readonly OrderSubtype order = new OrderSubtype();

		private Subtype () { }
	}
}
