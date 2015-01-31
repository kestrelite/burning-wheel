﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
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

