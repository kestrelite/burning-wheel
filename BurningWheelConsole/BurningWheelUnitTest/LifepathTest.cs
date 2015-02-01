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
        public void LifepathFetch()
        {
            LifepathAggregator.AggregateLifepaths();
            List<Lifepath> list = LifepathAggregator.getLifepathByStringName("Born Peasant");
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].Name, "Born Peasant");

            Lifepath lp = LifepathAggregator.getLifepathByStringNameSetting("Born Peasant", "Human_Peasant");
            Assert.IsNotNull(lp);
            Assert.AreNotSame(list[0], lp);
        }

        [TestMethod]
        public void BornLifepathsParseRace()
        {
            LifepathAggregator.AggregateLifepaths();
            List<Lifepath> list = LifepathAggregator.getBornLifepaths("Human");
            Assert.IsTrue(list.Count > 0);
            foreach (Lifepath lp in list)
            {
                Assert.IsTrue(lp.isBornLifepath);
            }

            List<Lifepath> list2 = LifepathAggregator.getBornLifepaths("FfweEFJIJfjf");
            Assert.IsTrue(list2.Count == 0);
        }

        [TestMethod]
        public void LifepathIsNotReference() //To ensure we're not modifying the base values stored in Aggregator
        {
            LifepathAggregator.AggregateLifepaths();
            List<Lifepath> listA = LifepathAggregator.getLifepathByStringName("Born Peasant");
            List<Lifepath> listB = LifepathAggregator.getLifepathByStringName("Born Peasant");
            Assert.AreNotSame(listA, listB);
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
