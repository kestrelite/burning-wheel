using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BurningWheelConsole.Properties;

namespace BurningWheelConsole
{
    public class Lifepath
    {
        public string Name { set; get; }
        public bool isBornLifepath { set; get; }
        public string Restrictions { set; get; }
        public int ResPoints { set; get; }
        public int Years { set; get; }
        public MPPoint MentalPhysical { set; get; }
        public string Setting { set; get; }
        public List<string> Leads { set; get; }
        public int SkillPoints { set; get; }
        public int GeneralSkillPoints { set; get; }
        public int TraitPoints { set; get; }
        public List<string> Skills { set; get; }
        public List<string> Traits { set; get; }
        public List<string> Prerequisites { set; get; }

        public bool LeadsTo(Lifepath lp2)
        {
            foreach (string s in Leads)
                if (s.Equals(lp2.Setting)) return true;

            //User may manually opt for lifepath that isn't lead to explicitly,
            //so the default behavior is to assume it's a lead.
            if (!Setting.Equals(lp2.Setting)) return true;

            return false;
        }

        public Lifepath()
        {

        }
    }
}
