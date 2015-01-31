using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Skill
    {
        private static List<Skill> _SKILL_AGGREGATE;
        public static List<Skill> SKILL_AGGREGATE
        {
            set
            {
                if (SKILL_AGGREGATE_SET) throw new InvalidOperationException("Can't set skill aggregate twice!");
                SKILL_AGGREGATE_SET = true;
                Skill._SKILL_AGGREGATE = value;
            }
            get { return Skill._SKILL_AGGREGATE; }
        }
        private static bool SKILL_AGGREGATE_SET = false;

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

