using BurningWheelConsole.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public static class SkillIndex
    {
        private static List<Skill> _SKILL_AGGREGATE;
        private static List<Skill> SKILL_AGGREGATE
        {
            get
            {
                if (_SKILL_AGGREGATE == null)
                {
                    _SKILL_AGGREGATE = JsonConvert.DeserializeObject<List<Skill>>(Resources.SkillsJSON);

                    foreach (Skill s in _SKILL_AGGREGATE)
                    {
                        NullReferenceException e = new NullReferenceException("Null field in Skill " + s.Name);

                        if (s.FoRKs == null) throw e;
                        if (s.Name == null) throw e;
                        if (s.Obstacles == null) throw e;
                        if (s.Restrictions == null) throw e;
                        if (s.SkillType == null) throw e;
                    }
                }

                return _SKILL_AGGREGATE;
            }
        }

        public static Skill getSkillByName(string name)
        {
            foreach (Skill s in SKILL_AGGREGATE)
            {
                if (s.Name.Equals(name)) return copySkill(s);
            }
            return null;
        }

        private static Skill copySkillList(List<Skill> skill)
        {
            string JSON = JsonConvert.SerializeObject(skill);
            return JsonConvert.DeserializeObject<Skill>(JSON);
        }

        private static Skill copySkill(Skill skill)
        {
            string JSON = JsonConvert.SerializeObject(skill);
            return JsonConvert.DeserializeObject<Skill>(JSON);
        }
    }
}
