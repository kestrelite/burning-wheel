using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public static class CharacterCalc
    {
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
         * Also, needs to take into account skills/traits already taken
         * 
         */
        public static int LifepathBornCount(Character character)
        {
            int count = 0;
            foreach (Lifepath lp in character.LifepathList)
                if (lp.isBornLifepath) count++;
            return count;
        }

        public static int LifepathLeadsCount(Character character)
        {
            int count = 0;
            Lifepath lastLP = null;
            foreach (Lifepath lp in character.LifepathList)
            {
                if (lastLP != null && lastLP.LeadsTo(lp)) count++;
                lastLP = lp;
            }
            return count;
        }

        public static int LifepathYearsCount(Character character)
        {
            int count = 0;
            foreach (Lifepath lp in character.LifepathList)
                count += lp.Years;
            count += LifepathLeadsCount(character);
            return count;
        }

        public static int LifepathGeneralPoints(Character character)
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in character.LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathIndex.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount < 2) count += lp.GeneralSkillPoints;
                if (duplicateCount == 2) count += lp.GeneralSkillPoints / 2;
                if (duplicateCount > 2) count += 0;

                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public static int LifepathSkillPoints(Character character)
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in character.LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathIndex.AreEquivalent(lp, lpTest)) duplicateCount++;
                //dupeCt is one less than the number of times the lifepath is taken
                if (duplicateCount < 2) count += lp.SkillPoints;
                if (duplicateCount == 2) count += lp.SkillPoints / 2;
                if (duplicateCount > 2) count += 0;

                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public static int LifepathTraitPoints(Character character)
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in character.LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathIndex.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount == 0) count += lp.TraitPoints;
                //This ternary statement checks the existence of a second trait.
                //If a second trait exists, then one less trait point is given the second time.
                if (duplicateCount == 1) count += lp.TraitPoints - (lp.Traits.Count >= duplicateCount + 1 ? 0 : 1);
                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public static int LifepathResourcePoints(Character character)
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();
            foreach (Lifepath lp in character.LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathIndex.AreEquivalent(lp, lpTest)) duplicateCount++;
                if (duplicateCount <= 1) count += lp.ResPoints;
                if (duplicateCount > 1) count += lp.ResPoints / 2;

                ProcessedLPs.Add(lp);
            }
            return count;
        }

        public static List<String> LifepathRequiredSkills(Character character)
        {
            List<String> RequiredSkills = new List<String>();
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in character.LifepathList)
            {
                List<string> skills = lp.Skills;
                foreach (string s1 in skills) {
                    if (RequiredSkills.Contains(s1)) continue;
                    RequiredSkills.Add(s1); break;
                }
                ProcessedLPs.Add(lp);
            }

            return RequiredSkills;
        }

        public static List<String> LifepathRequiredTraits(Character character)
        {
            List<String> RequiredTraits = new List<String>();
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in character.LifepathList)
            {
                List<string> traits = lp.Traits;
                foreach (string s1 in traits)
                {
                    if (RequiredTraits.Contains(s1)) continue;
                    RequiredTraits.Add(s1); break;
                }
                ProcessedLPs.Add(lp);
            }

            return RequiredTraits;
        }

        public static int LifepathMentalPoints(Character character)
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in character.LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathIndex.AreEquivalent(lp, lpTest)) duplicateCount++;
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

        public static int LifepathPhysicalPoints(Character character)
        {
            int count = 0;
            List<Lifepath> ProcessedLPs = new List<Lifepath>();

            foreach (Lifepath lp in character.LifepathList)
            {
                int duplicateCount = 0;
                foreach (Lifepath lpTest in ProcessedLPs)
                    if (LifepathIndex.AreEquivalent(lp, lpTest)) duplicateCount++;
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

        public static List<Lifepath> LifepathInconclusivePointsList(Character character)
        {
            List<Lifepath> inconclusiveLP = new List<Lifepath>();
            foreach (Lifepath lp in character.LifepathList)
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
