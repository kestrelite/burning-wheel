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
            //Sailor-wise, Ship-wise, Captian-wise

            Skill sailorWise = new Skill();
            sailorWise.BaseStat1 = RootStat.PERC;
            sailorWise.BaseStat2 = RootStat.NONE;
            sailorWise.FoRKs = new List<Skill>();
            sailorWise.Name = "Sailor-wise";
            sailorWise.Obstacles = new List<String>();
            sailorWise.ToolsExpendable = false;
            sailorWise.ToolsNeeded = false;
            sailorWise.Restrictions = "";
            sailorWise.SkillType = "Knowledge";

            Skill shipWise = new Skill();
            shipWise.BaseStat1 = RootStat.PERC;
            shipWise.BaseStat2 = RootStat.NONE;
            shipWise.FoRKs = new List<Skill>();
            shipWise.Name = "Ship-wise";
            shipWise.Obstacles = new List<String>();
            shipWise.ToolsExpendable = false;
            shipWise.ToolsNeeded = false;
            shipWise.Restrictions = "";
            shipWise.SkillType = "Knowledge";

            Skill captainWise = new Skill();
            captainWise.BaseStat1 = RootStat.PERC;
            captainWise.BaseStat2 = RootStat.NONE;
            captainWise.FoRKs = new List<Skill>();
            captainWise.Name = "Captain-wise";
            captainWise.Obstacles = new List<String>();
            captainWise.ToolsExpendable = false;
            captainWise.ToolsNeeded = false;
            captainWise.Restrictions = "";
            captainWise.SkillType = "Knowledge";
            
            List<Skill> list = new List<Skill>();
            list.Add(sailorWise);
            list.Add(shipWise);
            list.Add(captainWise);

            Console.WriteLine(JsonConvert.SerializeObject(list));

            /*
            Lifepath bornPeasant = new Lifepath();
            bornPeasant.Name = "Born Peasant";
            bornPeasant.isBornLifepath = true;
            bornPeasant.Restrictions = "";
            bornPeasant.ResPoints = 3;
            bornPeasant.Years = 8;
            bornPeasant.MentalPhysical = MPPoint.NONE;
            bornPeasant.Setting = "Human_Peasant";
            List<string> leads = new List<string>();
            leads.Add("Human_Servitude"); leads.Add("Human_Soldier"); leads.Add("Human_Seafaring"); leads.Add("Human_Religious");
            bornPeasant.Leads = leads;
            bornPeasant.SkillPoints = 0;
            bornPeasant.GeneralSkillPoints = 3;
            bornPeasant.TraitPoints = 0;
            bornPeasant.Skills = new List<Skill>();
            bornPeasant.Traits = new List<Trait>();

            Lifepath boy = new Lifepath();
            boy.Name = "Boy";
            boy.isBornLifepath = false;
            boy.Restrictions = "Must be the second lifepath taken, and may only be taken once.";
            boy.ResPoints = 8;
            boy.Years = 4;
            boy.MentalPhysical = MPPoint.NONE;
            boy.Setting = "Human_Seafaring";
            List<string> leads2 = new List<string>();
            leads2.Add("Human_City"); leads2.Add("Human_Servitude"); 
            leads2.Add("Human_Soldier"); leads2.Add("Human_Outcast");
            boy.Leads = leads2;
            boy.SkillPoints = 4;
            boy.GeneralSkillPoints = 0;
            boy.TraitPoints = 1;
            boy.Skills = new List<Skill>();
            boy.Traits = new List<Trait>();

            List<Lifepath> list = new List<Lifepath>();
            list.Add(bornPeasant);
            list.Add(boy);

            Console.WriteLine(JsonConvert.SerializeObject(list));
            //Console.ReadKey();*/
        }
    }
}
