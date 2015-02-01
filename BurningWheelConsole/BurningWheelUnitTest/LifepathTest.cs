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
            LifepathData.AggregateLifepaths();
            List<Lifepath> list = LifepathData.getLifepathByName("Born Peasant");
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].Name, "Born Peasant");

            Lifepath lp = LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            Assert.IsNotNull(lp);
            Assert.AreNotSame(list[0], lp);
        }

        [TestMethod]
        public void LifepathEquivalenceValid()
        {
            LifepathData.AggregateLifepaths();
            Lifepath lpA = LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring");
            Assert.IsNotNull(lpA);
            Lifepath lpB = LifepathData.getLifepathByNameSetting("Boy", "Human_Seafaring");
            Assert.IsNotNull(lpB);

            Assert.IsTrue(LifepathData.AreEquivalent(lpA, lpB));
        }

        [TestMethod]
        public void BornLifepathsParseRace()
        {
            LifepathData.AggregateLifepaths();
            List<Lifepath> list = LifepathData.getBornLifepathList("Human");
            Assert.IsTrue(list.Count > 0);
            foreach (Lifepath lp in list)
                Assert.IsTrue(lp.isBornLifepath);

            List<Lifepath> list2 = LifepathData.getBornLifepathList("FfweEFJIJfjf");
            Assert.IsTrue(list2.Count == 0);
        }

        [TestMethod]
        public void LifepathSearchByRace()
        {
            LifepathData.AggregateLifepaths();
            List<Lifepath> listA = LifepathData.getLifepathByRace("Human");
            List<Lifepath> listB = LifepathData.getLifepathByRace("Flimblejamble");
            Assert.AreNotEqual(0, listA.Count);
            Assert.AreEqual(0, listB.Count);
            foreach (Lifepath lp in listA)
                Assert.IsTrue(lp.Setting.StartsWith("Human"));

            Lifepath lpA = LifepathData.getLifepathByNameSetting("Born Peasant", "Human_Peasant");
            foreach (Lifepath lp in listA)
                Assert.AreNotSame(lp, lpA);
        }

        [TestMethod]
        public void LifepathIsNotReference() //To ensure we're not modifying the base values stored in Aggregator
        {
            LifepathData.AggregateLifepaths();
            List<Lifepath> listA = LifepathData.getLifepathByName("Born Peasant");
            List<Lifepath> listB = LifepathData.getLifepathByName("Born Peasant");
            Assert.AreNotSame(listA[0], listB[0]);
            listA[0].ResPoints = 23848;
            Assert.AreNotEqual(listA[0].ResPoints, listB[0].ResPoints);
        }

        [TestMethod]
        public void NoTwoLifepathsWithSameNameSetting()
        {
            List<Lifepath> lifepathdata = JsonConvert.DeserializeObject<List<Lifepath>>(Resources.LifepathsJSON);
            for (int i = 0; i < lifepathdata.Count; i++)
            {
                for (int j = 0; j < lifepathdata.Count; j++)
                {
                    //Assume there are no lifepaths with the same name AND setting
                    if (i == j) continue;
                    if (!lifepathdata[i].Name.Equals(lifepathdata[j].Name)) continue;
                    if (!lifepathdata[i].Setting.Equals(lifepathdata[j].Setting)) continue;
                    Assert.Fail("Dupe LPs: " + lifepathdata[i].Name + " in " + lifepathdata[i].Setting);
                }
            }
        }
    }
}
