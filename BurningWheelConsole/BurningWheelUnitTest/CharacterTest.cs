using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void CharacterReceivesLP()
        {
            Character c = new Character();
            Lifepath BornPeasant = LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            Assert.IsNotNull(BornPeasant);

            c.AddLifepath(BornPeasant);
            Assert.AreEqual(c.LifepathList.Count, 1);

            Assert.IsTrue(c.DropLifepath(BornPeasant));
            Assert.IsFalse(c.DropLifepath(BornPeasant));
        }

        [TestMethod]
        public void CharacterCalcsLP_NoDuplicates()
        {
            Character c = new Character();
            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            Assert.AreEqual(CharacterCalc.LifepathLeadsCount(c), 0);
            Assert.AreEqual(0, CharacterCalc.LifepathRequiredSkills(c).Count);
            Assert.AreEqual(0, CharacterCalc.LifepathRequiredTraits(c).Count);
            Assert.AreEqual(8, CharacterCalc.LifepathYearsCount(c));

            //Ensure same setting doesn't lead
            Lifepath tmpLP = LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            c.AddLifepath(tmpLP);
            Assert.AreEqual(2, c.LifepathList.Count);
            Assert.AreEqual(0, CharacterCalc.LifepathLeadsCount(c));
            c.DropLifepath(tmpLP);
            Assert.AreEqual(1, c.LifepathList.Count);

            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            Assert.AreEqual(1, CharacterCalc.LifepathBornCount(c));
            Assert.AreEqual(11, CharacterCalc.LifepathResourcePoints(c));
            Assert.AreEqual(1, CharacterCalc.LifepathLeadsCount(c));
            Assert.AreEqual(13, CharacterCalc.LifepathYearsCount(c)); //8 + 4 (+ 1 Leads)
            Assert.AreEqual(3, CharacterCalc.LifepathGeneralPoints(c));
            Assert.AreEqual(4, CharacterCalc.LifepathSkillPoints(c));
            Assert.AreEqual(3, CharacterCalc.LifepathTraitPoints(c));
            Assert.AreEqual(1, CharacterCalc.LifepathRequiredSkills(c).Count);
            Assert.AreEqual("Sailor-wise", CharacterCalc.LifepathRequiredSkills(c)[0], CharacterCalc.LifepathRequiredSkills(c)[0]);
            Assert.AreEqual(1, CharacterCalc.LifepathRequiredTraits(c).Count);
            Assert.AreEqual("Veneer of Obedience", CharacterCalc.LifepathRequiredTraits(c)[0]);

            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            Assert.AreEqual(17, CharacterCalc.LifepathYearsCount(c)); //8 + 4 + 4 (+ 1 Leads)
        }

        [TestMethod]
        public void CharacterCalcsLP_WithDuplicates()
        {
            Character c = new Character();

            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            //Assertions for two the same
            Assert.AreEqual(2, CharacterCalc.LifepathRequiredTraits(c).Count);
            Assert.AreEqual(2, CharacterCalc.LifepathRequiredSkills(c).Count);
            Assert.AreEqual("Sailor-wise", CharacterCalc.LifepathRequiredSkills(c)[0]);
            Assert.AreEqual("Ship-wise", CharacterCalc.LifepathRequiredSkills(c)[1]);
            Assert.AreEqual("Veneer of Obedience", CharacterCalc.LifepathRequiredTraits(c)[0]);
            Assert.AreEqual("Curses like a Sailor", CharacterCalc.LifepathRequiredTraits(c)[1]);
            Assert.AreEqual(8, CharacterCalc.LifepathSkillPoints(c));
            Assert.AreEqual(2, CharacterCalc.LifepathTraitPoints(c));
            Assert.AreEqual(16, CharacterCalc.LifepathResourcePoints(c));

            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            //Assertions for three the same
            Assert.AreEqual(2, CharacterCalc.LifepathRequiredTraits(c).Count);
            Assert.AreEqual(2, CharacterCalc.LifepathRequiredSkills(c).Count);
            Assert.AreEqual(10, CharacterCalc.LifepathSkillPoints(c));
            Assert.AreEqual(2, CharacterCalc.LifepathTraitPoints(c));
            Assert.AreEqual(20, CharacterCalc.LifepathResourcePoints(c));

            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            //Assertions for four the same
            Assert.AreEqual(2, CharacterCalc.LifepathRequiredTraits(c).Count);
            Assert.AreEqual(2, CharacterCalc.LifepathRequiredSkills(c).Count);
            Assert.AreEqual(10, CharacterCalc.LifepathSkillPoints(c));
            Assert.AreEqual(2, CharacterCalc.LifepathTraitPoints(c));
            Assert.AreEqual(24, CharacterCalc.LifepathResourcePoints(c));

            //Testing for second trait and general SPs
            c = new Character();
            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            c.AddLifepath(LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            Assert.AreEqual(4, c.LifepathList.Count);
            Assert.AreEqual(3, CharacterCalc.LifepathTraitPoints(c));
            Assert.AreEqual(7, CharacterCalc.LifepathGeneralPoints(c));
        }

        /*[TestMethod]
        public void CharacterCalcMP()
        {
            Assert.Inconclusive("No test for MP");
            //No stat point after second instance
        }*/
    }
}
