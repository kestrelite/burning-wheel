using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Lifepath
    {
        public string Name { set; get; }
        public string Restrictions { set; get; }
        public int Resources { set; get; }
        public int Years { set; get; }
        public MPPoint MentalPhysical { set; get; }
        public string Setting { set; get; }
        public List<string> Leads { set; get; }
        public int SkillPoints { set; get; }
        public int TraitPoints { set; get; }
        public List<Skill> Skills { set; get; }
        public List<Trait> Traits { set; get; }
        
        public bool LeadsTo(Lifepath lp2)
        {
            foreach (string s in Leads)
            {
                if (s.Equals(lp2.Setting)) return true;
                Console.Write(s + "; " + lp2.Setting);
            }
             
            return false;
        }

        public Lifepath()
        {

        }
    }
}
