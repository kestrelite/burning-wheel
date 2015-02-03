using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BurningWheelConsole.Properties;

namespace BurningWheelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TraitIndex.getTraitByName("Veneer of Obedience");
            SkillIndex.getSkillByName("Ship-wise");
            LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring");
        }
    }
}
