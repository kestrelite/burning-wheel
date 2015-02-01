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
            //Todo: Fix Skill/Trait requirements for always-enabled
            //Todo: Add previous lifepath requirements to LP
            Character c = new Character();
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.LPCalc_TraitPoints();
        }
    }
}
