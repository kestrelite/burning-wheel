using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BurningWheelConsole
{
    public class Lifepath
    {
        private static List<Lifepath> _LIFEPATH_AGGREGATE;
        public static List<Lifepath> LIFEPATH_AGGREGATE 
        {
            set 
            { 
                if (LIFEPATH_AGGREGATE_SET) throw new InvalidOperationException("Can't set lifepath aggregate twice!");
                LIFEPATH_AGGREGATE_SET = true;
                Lifepath._LIFEPATH_AGGREGATE = value;
            }
            get { return Lifepath._LIFEPATH_AGGREGATE; } 
        }
        private static bool LIFEPATH_AGGREGATE_SET = false;

        public string Name { set; get; }
        public bool isBornLifepath { set; get; }
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
