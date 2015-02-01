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
            LifepathData.AggregateLifepaths();
            Character c = new Character();
            Lifepath BornPeasant = LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            Assert.IsNotNull(BornPeasant);

            c.AddLifepath(BornPeasant);
            Assert.AreEqual(c.GetLifepathList().Count, 1);

            Assert.IsTrue(c.DropLifepath(BornPeasant));
            Assert.IsFalse(c.DropLifepath(BornPeasant));
        }

        [TestMethod]
        public void CharacterCalcsLP_NoDuplicates()
        {
            LifepathData.AggregateLifepaths();
            Character c = new Character();
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            Assert.AreEqual(c.LPCalc_CountLeads(), 0);
            Assert.AreEqual(0, c.LPCalc_RequiredSkills().Count);
            Assert.AreEqual(0, c.LPCalc_RequiredTraits().Count);
            Assert.AreEqual(8, c.LPCalc_CountYears());

            //Ensure same setting doesn't lead
            Lifepath tmpLP = LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            c.AddLifepath(tmpLP);
            Assert.AreEqual(2, c.GetLifepathList().Count);
            Assert.AreEqual(0, c.LPCalc_CountLeads());
            c.DropLifepath(tmpLP);
            Assert.AreEqual(1, c.GetLifepathList().Count);

            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            Assert.AreEqual(1, c.LPCalc_BornCount());
            Assert.AreEqual(11, c.LPCalc_ResPoints());
            Assert.AreEqual(1, c.LPCalc_CountLeads());
            Assert.AreEqual(13, c.LPCalc_CountYears()); //8 + 4 (+ 1 Leads)
            Assert.AreEqual(3, c.LPCalc_GeneralPoints());
            Assert.AreEqual(4, c.LPCalc_SkillPoints());
            Assert.AreEqual(3, c.LPCalc_TraitPoints());
            Assert.AreEqual(1, c.LPCalc_RequiredSkills().Count);
            Assert.AreEqual("Sailor-wise", c.LPCalc_RequiredSkills()[0], c.LPCalc_RequiredSkills()[0]);
            Assert.AreEqual(1, c.LPCalc_RequiredTraits().Count);
            Assert.AreEqual("Veneer of Obedience", c.LPCalc_RequiredTraits()[0]);

            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            Assert.AreEqual(17, c.LPCalc_CountYears()); //8 + 4 + 4 (+ 1 Leads)
        }

        [TestMethod]
        public void CharacterCalcsLP_WithDuplicates()
        {
            LifepathData.AggregateLifepaths();
            Character c = new Character();

            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            //Assertions for two the same
            Assert.AreEqual(2, c.LPCalc_RequiredTraits().Count);
            Assert.AreEqual(2, c.LPCalc_RequiredSkills().Count);
            Assert.AreEqual("Sailor-wise", c.LPCalc_RequiredSkills()[0]);
            Assert.AreEqual("Ship-wise", c.LPCalc_RequiredSkills()[1]);
            Assert.AreEqual("Veneer of Obedience", c.LPCalc_RequiredTraits()[0]);
            Assert.AreEqual("Curses like a Sailor", c.LPCalc_RequiredTraits()[1]);
            Assert.AreEqual(8, c.LPCalc_SkillPoints());
            Assert.AreEqual(2, c.LPCalc_TraitPoints());
            Assert.AreEqual(16, c.LPCalc_ResPoints());

            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            //Assertions for three the same
            Assert.AreEqual(2, c.LPCalc_RequiredTraits().Count);
            Assert.AreEqual(2, c.LPCalc_RequiredSkills().Count);
            Assert.AreEqual(10, c.LPCalc_SkillPoints());
            Assert.AreEqual(2, c.LPCalc_TraitPoints());
            Assert.AreEqual(20, c.LPCalc_ResPoints());

            c.AddLifepath(LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring"));
            //Assertions for four the same
            Assert.AreEqual(2, c.LPCalc_RequiredTraits().Count);
            Assert.AreEqual(2, c.LPCalc_RequiredSkills().Count);
            Assert.AreEqual(10, c.LPCalc_SkillPoints());
            Assert.AreEqual(2, c.LPCalc_TraitPoints());
            Assert.AreEqual(24, c.LPCalc_ResPoints());

            //Testing for second trait and general SPs
            c = new Character();
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            c.AddLifepath(LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant"));
            Assert.AreEqual(4, c.GetLifepathList().Count);
            Assert.AreEqual(3, c.LPCalc_TraitPoints());
            Assert.AreEqual(7, c.LPCalc_GeneralPoints());
        }

        /*[TestMethod]
        public void CharacterCalcMP()
        {
            Assert.Inconclusive("No test for MP");
            //No stat point after second instance
        }*/
    }
}
