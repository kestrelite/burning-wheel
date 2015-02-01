using BurningWheelConsole.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class SkillAggregator
    {
        private static List<Skill> _SKILL_AGGREGATE;
        public static List<Skill> SKILL_AGGREGATE
        {
            get
            {
                return _SKILL_AGGREGATE
                    ?? (_SKILL_AGGREGATE = JsonConvert.DeserializeObject<List<Skill>>(Resources.SkillsJSON));
            }
        }

        public static int AggregateSkills() { return SKILL_AGGREGATE.Count; }

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

    public class Skill
    {
        public string Name { set; get; }
        public string Restrictions { set; get; }
        public string SkillType { set; get; }
        public RootStat BaseStat1 { set; get; }
        public RootStat BaseStat2 { set; get; }
        public List<String> Obstacles { set; get; }
        public bool ToolsNeeded { set; get; }
        public bool ToolsExpendable { set; get; }
        public List<Skill> FoRKs { set; get; }
    }
}

