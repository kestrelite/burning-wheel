using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;
using System.Collections.Generic;
using Newtonsoft.Json;
using BurningWheelConsole.Properties;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class LifepathTest
    {
        [TestMethod]
        public void LifepathFetchCorrectly()
        {
            List<Lifepath> list = LifepathIndex.getLifepathByName("Born Peasant");
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].Name, "Born Peasant");

            Lifepath lp = LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            Assert.IsNotNull(lp);
            Assert.AreNotSame(list[0], lp);
        }

        [TestMethod]
        public void LifepathEquivalenceValid()
        {
            Lifepath lpA = LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring");
            Assert.IsNotNull(lpA);
            Lifepath lpB = LifepathIndex.getLifepathByNameSetting("Boy", "Human_Seafaring");
            Assert.IsNotNull(lpB);

            Assert.IsTrue(LifepathIndex.AreEquivalent(lpA, lpB));
        }

        [TestMethod]
        public void BornLifepathsParseRace()
        {
            List<Lifepath> list = LifepathIndex.getBornLifepathList("Human");
            Assert.IsTrue(list.Count > 0);
            foreach (Lifepath lp in list)
                Assert.IsTrue(lp.isBornLifepath);

            List<Lifepath> list2 = LifepathIndex.getBornLifepathList("FfweEFJIJfjf");
            Assert.IsTrue(list2.Count == 0);
        }

        [TestMethod]
        public void LifepathSearchByRace()
        {
            List<Lifepath> listA = LifepathIndex.getLifepathByRace("Human");
            List<Lifepath> listB = LifepathIndex.getLifepathByRace("Flimblejamble");
            Assert.AreNotEqual(0, listA.Count);
            Assert.AreEqual(0, listB.Count);
            foreach (Lifepath lp in listA)
                Assert.IsTrue(lp.Setting.StartsWith("Human"));

            Lifepath lpA = LifepathIndex.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            foreach (Lifepath lp in listA)
                Assert.AreNotSame(lp, lpA);
        }

        [TestMethod]
        public void LifepathIsNotReference() //To ensure we're not modifying the base values stored in Aggregator
        {
            List<Lifepath> listA = LifepathIndex.getLifepathByName("Born Peasant");
            List<Lifepath> listB = LifepathIndex.getLifepathByName("Born Peasant");
            Assert.AreNotSame(listA[0], listB[0]);
            listA[0].ResPoints = 23848;
            Assert.AreNotEqual(listA[0].ResPoints, listB[0].ResPoints);
        }

        [TestMethod]
        public void NoTwoLifepathsWithSameNameSetting()
        {
            List<Lifepath> LifepathIndex = JsonConvert.DeserializeObject<List<Lifepath>>(Resources.LifepathsJSON);
            for (int i = 0; i < LifepathIndex.Count; i++)
            {
                for (int j = 0; j < LifepathIndex.Count; j++)
                {
                    //Assume there are no lifepaths with the same name AND setting
                    if (i == j) continue;
                    if (!LifepathIndex[i].Name.Equals(LifepathIndex[j].Name)) continue;
                    if (!LifepathIndex[i].Setting.Equals(LifepathIndex[j].Setting)) continue;
                    Assert.Fail("Dupe LPs: " + LifepathIndex[i].Name + " in " + LifepathIndex[i].Setting);
                }
            }
        }
    }
}
