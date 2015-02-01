using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Character
    {
        public string Race { set; get; }
        private List<Lifepath> LifepathList = new List<Lifepath>();

        //START LIFEPATH HANDLING
        public List<Lifepath> GetLifepathList() { return LifepathList; }

        public void AddLifepath(Lifepath lp)
        {
            if (lp == null) throw new ArgumentNullException();
            LifepathList.Add(lp);
        }

        //Bool indicates whether the item was actually in the list at all
        public bool DropLifepath(Lifepath lp)
        {
            if (LifepathList.Contains(lp))
            {
                LifepathList.Remove(lp);
                return true;
            }
            return false;
        }
        //END LIFEPATH HANDLING

        //START LIFEPATH CALCULATIONS

        /*
         * Ahem. Let me clear my throat a minute and explain the godawful
         * mess of code you are looking at. I will explain it with a quote
         * from BWG, page 84.
         * 
         * Repeating Lifepaths: The Law of Diminishing Returns
         * ---------------------------------------------------
         * 
         * You can repeat a lifepath as many times as you like. The second
         * time a path is taken, time, resources, stat and skill points are
         * earned as normal. The second skill and trait on each lifepath are
         * required. If there is no second trait, subtract one point from
         * the path. The third time a character walks a lifepath, he only
         * receives half of the skill and resource points but no trait or 
         * stat points. If a lifepath is taken a fourth time, the character
         * only earns half of the resource points and nothing else aside
         * from years.
         *
         */
        public int LPCalc_BornCount()
        {
            int count = 0;
            foreach (Lifepath lp in LifepathList)
                if (lp.isBornLifepath) count++;
            return count;
        }

        public int LPCalc_CountLeads()
        {
            int count = 0;
            Lifepath lastLP = null;
            foreach (Lifepath lp in LifepathList)
            {
                if (lastLP != null && lastLP.LeadsTo(lp)) count++;
                lastLP = lp;
            }
            return count;
        }

        public int LPCalc_CountYears()
        {
            int count = 0;
            foreach (Lifepath lp in LifepathList)
                count += lp.Years;
            count += LPCalc_CountLeads();
            return count;
        }

        public int LPCalc_GeneralPoints()
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount < 2) count += lp.GeneralSkillPoints;
                if (duplicateCount == 2) count += lp.GeneralSkillPoints / 2;
                if (duplicateCount > 2) count += 0;

                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public int LPCalc_SkillPoints()
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                //dupeCt is one less than the number of times the lifepath is taken
                if (duplicateCount < 2) count += lp.SkillPoints;
                if (duplicateCount == 2) count += lp.SkillPoints / 2;
                if (duplicateCount > 2) count += 0;

                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public int LPCalc_TraitPoints()
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount == 0) count += lp.TraitPoints;
                if (duplicateCount == 1) count += lp.TraitPoints - (lp.Traits.Count >= 2 ? 0 : 1);
                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public int LPCalc_ResPoints()
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount <= 1) count += lp.ResPoints;
                if (duplicateCount > 1) count += lp.ResPoints / 2;

                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public List<String> LPCalc_RequiredSkills()
        {
            List<String> RequiredSkills = new List<String>();
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                //Only requires up to the second trait
                if (lp.Skills.Count > duplicateCount && duplicateCount < 2)
                    RequiredSkills.Add(lp.Skills[duplicateCount]);
                ProcessedLPs.Add(lp);
            }

            return RequiredSkills;
        }

        public List<String> LPCalc_RequiredTraits()
        {
            List<String> RequiredTraits = new List<String>();
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                //Only requires up to the second trait
                if (lp.Traits.Count > duplicateCount && duplicateCount < 2)
                    RequiredTraits.Add(lp.Traits[duplicateCount]);
                ProcessedLPs.Add(lp);
            }

            return RequiredTraits;
        }

        public int LPCalc_MPoint()
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount <= 1) //No stat points for >2 walks
                {
                    if (lp.MentalPhysical.Equals(MPPoint.NEG_M)) count -= 1;
                    if (lp.MentalPhysical.Equals(MPPoint.NEG_MP)) count -= 1;
                    if (lp.MentalPhysical.Equals(MPPoint.POS_M)) count += 1;
                    if (lp.MentalPhysical.Equals(MPPoint.POS_MP)) count += 1;
                }

                ProcessedLPs.Add(lp);
            }

            return count;
        }

        public int LPCalc_PPoint()
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathData.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount <= 1) //No stat points for >2 walks
                {
                    if (lp.MentalPhysical.Equals(MPPoint.NEG_P)) count -= 1;
                    if (lp.MentalPhysical.Equals(MPPoint.NEG_MP)) count -= 1;
                    if (lp.MentalPhysical.Equals(MPPoint.POS_P)) count += 1;
                    if (lp.MentalPhysical.Equals(MPPoint.POS_MP)) count += 1;
                }

                ProcessedLPs.Add(lp);
            }

            return count;
        }

        public List<Lifepath> LPCalc_MPInconclusive()
        {
            List<Lifepath> inconclusiveLP = new List<Lifepath>();
            foreach (Lifepath lp in LifepathList)
            {
                if (lp.MentalPhysical.Equals(MPPoint.NEG_MorP))
                    inconclusiveLP.Add(lp);
                if (lp.MentalPhysical.Equals(MPPoint.POS_MorP))
                    inconclusiveLP.Add(lp);
            }
            return inconclusiveLP;
        }
    }
}
