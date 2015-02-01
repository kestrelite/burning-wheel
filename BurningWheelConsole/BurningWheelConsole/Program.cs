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
            Character c = new Character();
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.LPCalc_TraitPoints();

            return;
            Lifepath lp1 = LifepathData.getLifepathByName("Boy")[0];
            Lifepath lp2 = LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring");
            Console.WriteLine(lp1.Setting);
            Console.WriteLine(lp2 == null ? "NULL" : "NOT NULL");
        }
    }
}
