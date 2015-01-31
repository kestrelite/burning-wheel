using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BurningWheelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Lifepath l = new Lifepath();
            l.Name = "Test";
            l.Leads = new List<string>();
            l.Leads.Add("Outcast");

            Console.WriteLine(JsonConvert.SerializeObject(l));
            Console.ReadKey();

            Lifepath l2 = JsonConvert.DeserializeObject<Lifepath>("{\"Name\":\"Test\"}");
            Console.WriteLine(l2.Name);
        }
    }
}
