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
            Skill s = new Skill();
            s.BaseStat1 = RootStat.PERC;
            s.BaseStat2 = RootStat.NONE;
            s.Name = "TestSkill";
            s.Obstacles = new List<string>();
            s.ToolsNeeded = true;

            List<Skill> list = new List<Skill>();
            list.Add(s);

            Console.WriteLine(JsonConvert.SerializeObject(list));
            Console.ReadKey();

            Lifepath l2 = JsonConvert.DeserializeObject<Lifepath>("{\"Name\":\"Test\"}");
            Console.WriteLine(l2.Name);

            Console.WriteLine(Resources.LifepathsJSON);
            Console.ReadKey();
        }
    }
}
