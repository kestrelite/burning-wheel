using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BurningWheelConsole.Properties;

namespace BurningWheelConsole
{
    public class LifepathAggregator
    {
        private static List<Lifepath> _LIFEPATH_AGGREGATE;
        private static List<Lifepath> LIFEPATH_AGGREGATE
        {
            get
            {
                return _LIFEPATH_AGGREGATE
                    ?? (_LIFEPATH_AGGREGATE = JsonConvert.DeserializeObject<List<Lifepath>>(Resources.LifepathsJSON));
            }
        }

        public static int AggregateLifepaths() { return LIFEPATH_AGGREGATE.Count(); }

        public static List<Lifepath> getLifepathByStringName(string name)
        {
            List<Lifepath> ret = new List<Lifepath>();
            foreach (Lifepath lp in LIFEPATH_AGGREGATE)
            {
                if (lp.Name.Equals(name)) ret.Add(lp);
            }

            return copyLifepathsList(ret);
        }

        public static Lifepath getLifepathByStringNameSetting(string name, string setting)
        {
            foreach (Lifepath lp in LIFEPATH_AGGREGATE)
                if (lp.Name.Equals(name) && lp.Setting.Equals(setting)) return copyLifepath(lp);
            return null;
        }

        public static List<Lifepath> getBornLifepaths(string race)
        {
            List<Lifepath> ret = new List<Lifepath>();
            foreach (Lifepath lp in LIFEPATH_AGGREGATE)
            {
                if (lp.isBornLifepath && lp.Setting.StartsWith(race)) ret.Add(lp);
                Console.WriteLine(lp.Setting.StartsWith(race));
            }

            return copyLifepathsList(ret);
        }

        private static List<Lifepath> copyLifepathsList(List<Lifepath> lpList)
        {
            string JSON = JsonConvert.SerializeObject(lpList);
            return JsonConvert.DeserializeObject<List<Lifepath>>(JSON);
        }

        private static Lifepath copyLifepath(Lifepath lp)
        {
            string serialized = JsonConvert.SerializeObject(lp);
            return JsonConvert.DeserializeObject<Lifepath>(serialized);
        }

        private LifepathAggregator() { }
    }

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
        public List<String> Skills { set; get; }
        public List<String> Traits { set; get; }

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
