using System;

namespace BurningWheelConsole
{
	class Trait
	{
		public string Name { set; get; }
		public string Restrictions { set; get; }
		public bool LPOnlyTrait { set; get; }
		public int Points { set; get; }
		public TraitType TraitType { set; get; }
	}
}
