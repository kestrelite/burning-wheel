using System;

namespace BurningWheelConsole
{
	class Lifepath
	{
		public string Name { set; get; }
		public string Restrictions { set; get; }
		public int Resources { set; get; }
		public int Years { set; get; }
		public MPPoint MentalPhysical { set; get; }
		public LPSetting Setting { set; get; }
		public LPLeads Leads { set; get; }
		public int SkillPoints { set; get; }
		public int TraitPoints { set; get; }
		public List<Skill> Skills { set; get; }
		public List<Trait> Traits { set; get; }
		public bool LeadsTo(Lifepath arg1)
		{
		}
	}
}
