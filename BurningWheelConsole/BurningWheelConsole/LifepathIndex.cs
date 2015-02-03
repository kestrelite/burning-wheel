using BurningWheelConsole.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public static class LifepathIndex
    {
        private static List<Lifepath> _LIFEPATH_AGGREGATE;
        private static List<Lifepath> LIFEPATH_AGGREGATE
        {
            get
            {
                if (_LIFEPATH_AGGREGATE == null) { 
                    _LIFEPATH_AGGREGATE = JsonConvert.DeserializeObject<List<Lifepath>>(Resources.LifepathsJSON);

                    foreach (Lifepath lp in _LIFEPATH_AGGREGATE)
                    {
                        NullReferenceException e = new NullReferenceException("Null field in Lifepath " + lp.Name);
                        if (lp.Leads == null) throw e;
                        if (lp.Name == null) throw e;
                        if (lp.Prerequisites == null) throw e;
                        if (lp.Restrictions == null) throw e;
                        if (lp.Setting == null) throw e;
                        if (lp.Skills == null) throw e;
                        if (lp.Traits == null) throw e;
                    }
                }

                return _LIFEPATH_AGGREGATE;
            }
        }

        public static List<Lifepath> getLifepathByName(string name)
        {
            List<Lifepath> ret = new List<Lifepath>();
            foreach (Lifepath lp in LIFEPATH_AGGREGATE)
                if (lp.Name.Equals(name)) ret.Add(lp);
            return copyLifepathsList(ret);
        }

        public static List<Lifepath> getLifepathByRace(string race)
        {
            List<Lifepath> ret = new List<Lifepath>();
            foreach (Lifepath lp in LIFEPATH_AGGREGATE)
                if (lp.Setting.StartsWith(race)) ret.Add(lp);
            return copyLifepathsList(ret);
        }

        public static Lifepath getLifepathByNameSetting(string name, string setting)
        {
            foreach (Lifepath lp in LIFEPATH_AGGREGATE)
                if (lp.Name.Equals(name) && lp.Setting.Equals(setting)) return copyLifepath(lp);
            return null;
        }

        public static List<Lifepath> getBornLifepathList(string race)
        {
            List<Lifepath> ret = new List<Lifepath>();
            foreach (Lifepath lp in LIFEPATH_AGGREGATE)
                if (lp.isBornLifepath && lp.Setting.StartsWith(race)) ret.Add(lp);
            return copyLifepathsList(ret);
        }

        public static bool AreEquivalent(Lifepath lpA, Lifepath lpB)
        {
            return (lpA.Name.Equals(lpB.Name) && lpA.Setting.Equals(lpB.Setting));
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
    }
}
