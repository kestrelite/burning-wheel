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
            Trait t = new Trait();
            t.LPOnlyTrait = false;
            t.Name = "Veneer of Obedience";
            t.Points = 1;
            t.Restrictions = "";
            t.Type = TraitType.CHAR;

            List<Trait> list = new List<Trait>();
            list.Add(t);
            Console.WriteLine(JsonConvert.SerializeObject(list));


            //LifepathAggregator.AggregateLifepaths();
            //Lifepath p = LifepathAggregator.getLifepathByStringName("Boy")[0];
            //p.Skills.Add("Ship-wise");
            //p.Skills.Add("Captain-wise");
            //p.Skills.Add("Sailor-wise");

            //Console.WriteLine(JsonConvert.SerializeObject(p));
        }
    }
}
