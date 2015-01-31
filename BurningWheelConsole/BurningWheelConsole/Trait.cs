using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Trait
    {
        public string Name { set; get; }
        public string Restrictions { set; get; }
        public bool LPOnlyTrait { set; get; }
        public int Points { set; get; }
        public TraitType TraitType { set; get; }
    }
}

